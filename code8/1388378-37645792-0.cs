    public class LettersTextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
    
            string c = e.KeyChar.ToString();
    
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z' || char.IsControl(e.KeyChar))
                return;
    
            e.Handled = true;
        }
    
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_PASTE = 0x0302;
            if (m.Msg == WM_PASTE)
            {
                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text))
                    return;
    
                if (text.Any(c => c < 'a' || c > 'z'))
                {
                    SelectedText = new string(text.Where(c => c >= 'a' && c <= 'z').ToArray());
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
