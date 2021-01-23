    using System;
    
    using System.Windows.Forms;
    
    public class numericTextbox : TextBox
    {
        private const int WM_PASTE = 0x302;
    
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            string Value = this.Text;
            Value = Value.Remove(this.SelectionStart, this.SelectionLength);
            Value = Value.Insert(this.SelectionStart, e.KeyChar.ToString());
            e.Handled = Convert.ToBoolean(Value.LastIndexOf("-") > 0) || 
                !(char.IsControl(e.KeyChar) || 
                  char.IsDigit(e.KeyChar) || 
                (e.KeyChar == '.' && !(this.Text.Contains(".")) || 
                 e.KeyChar == '.' && this.SelectedText.Contains(".")) || 
                (e.KeyChar == '-' && this.SelectionStart == 0));
    
            base.OnKeyPress(e);
    
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                string Value = this.Text;
                Value = Value.Remove(this.SelectionStart, this.SelectionLength);
                Value = Value.Insert(this.SelectionStart, Clipboard.GetText());
                decimal result = 0M;
                if (!(decimal.TryParse(Value, out result)))
                {
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
