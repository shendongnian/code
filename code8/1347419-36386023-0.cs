    public class CustomTextBox : System.Windows.Forms.TextBox
    {
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && this.Text.IndexOf('.') != -1) //Replaced 'tbL1Distance' with 'this' to refer to the current TextBox.
            {
                e.Handled = true;
            }
            else if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
    }
