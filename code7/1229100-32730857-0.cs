    public class DigitsOnlyOnPasteTextBox : TextBox
    {
        private const int WM_PASTE = 0x302;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE && Clipboard.ContainsText())
            {
                int i;
                string txt = Clipboard.GetText();
                foreach(char c in txt)
                {
                    if (!char.IsNumber(c))
                    {
                        return;// suppress default behavior
                    }
                }
            }
            base.WndProc(ref m); // allow normal processing of the message
        }
    }
