    public static class RichTextBoxExtensions
    {
        public static void SetTextOrRtf(this RichTextBox richTextBox, IEnumerable<string> texts)
        {
            if (richTextBox == null || texts == null)
                throw new ArgumentNullException();
            using (richTextBox.BeginUpdate())
            {
                bool first = true;
                richTextBox.Clear();
                foreach (var text in texts)
                {
                    if (text == null)
                        continue;
                    if (first)
                        first = false;
                    else
                        richTextBox.AppendText("\n");
                    richTextBox.Select(richTextBox.TextLength, 0);
                    if (text.IsRtf())
                    {
                        richTextBox.SelectedRtf = text;
                    }
                    else
                    {
                        richTextBox.SelectedText = text;
                    }
                }
                richTextBox.SelectionStart = richTextBox.Text.Length;
                richTextBox.ScrollToCaret();
            }
        }
        public static bool IsRtf(this string text)
        {
            // Adapted from http://stackoverflow.com/questions/22502924/how-to-determine-text-format-in-c-sharp
            if (text == null)
                return false;
            const string rtfPrefix = @"{\rtf1";
            int start = 0;
            for (; start < text.Length && Char.IsWhiteSpace(text[start]); start++)
                ;
            return string.Compare(text, start, rtfPrefix, 0, rtfPrefix.Length, StringComparison.Ordinal) == 0;
        }
        private const int WM_USER = 0x0400;
        private const int EM_SETEVENTMASK = (WM_USER + 69);
        private const int WM_SETREDRAW = 0x0b;
        class ResetEventMask : IDisposable
        {
            readonly IntPtr oldEventMask;
            RichTextBox richTextBox;
            public ResetEventMask(RichTextBox richTextBox, IntPtr oldEventMask)
            {
                this.richTextBox = richTextBox;
                this.oldEventMask = oldEventMask;
            }
            #region IDisposable Members
            public void Dispose()
            {
                var richTextBox = Interlocked.Exchange(ref this.richTextBox, null);
                if (richTextBox != null && !richTextBox.IsDisposed)
                {
                    SendMessage(richTextBox.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
                    SendMessage(richTextBox.Handle, EM_SETEVENTMASK, IntPtr.Zero, oldEventMask);
                }
            }
            #endregion
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public static IDisposable BeginUpdate(this RichTextBox richTextBox)
        {
            if (richTextBox == null)
                throw new ArgumentNullException();
            // Adapted from http://stackoverflow.com/questions/192413/how-do-you-prevent-a-richtextbox-from-refreshing-its-display
            SendMessage(richTextBox.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
            var oldEventMask = (IntPtr)SendMessage(richTextBox.Handle, EM_SETEVENTMASK, IntPtr.Zero, IntPtr.Zero);
            return new ResetEventMask(richTextBox, oldEventMask);
        }
    }
