    using System.Windows.Forms;
    public class ExTextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if(e.KeyChar==' ' && ModifierKeys== Keys.Control)
                e.KeyChar='\u200B';
            base.OnKeyPress(e);
        }
    }
