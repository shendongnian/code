        private const int WM_SETREDRAW = 0xB;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        List<string> names = new List<string>
        {
            "john",
            "doe",
            "jack",
            "liza",
            "sandy",
            "sara"
        };
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            SendMessage(richTextBox1.Handle, WM_SETREDRAW, false, 0);
            int prevStart = richTextBox1.SelectionStart;
            int prevLength = richTextBox1.SelectionLength;
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
            foreach (string name in names)
            {
                foreach (Match match in Regex.Matches(richTextBox1.Text, Regex.Escape(name)))
                {
                    richTextBox1.Select(match.Index, match.Length);
                    richTextBox1.SelectionColor = Color.Red;
                }
            }
            richTextBox1.Select(prevStart, prevLength);
            SendMessage(richTextBox1.Handle, WM_SETREDRAW, true, 0);
            richTextBox1.Invalidate();
        }
