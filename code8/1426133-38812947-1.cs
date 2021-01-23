    using System.Windows.Forms;
    public class MyButton:Button
    {
        protected override bool ProcessMnemonic(char charCode)
        {
            if (this.UseMnemonic && this.Enabled && this.Visible &&
                Control.IsMnemonic(charCode, this.Text))
            {
                if (!this.Focused)
                {
                    this.Focus();
                    return true;
                }
            }
            return false;
        }
    }
