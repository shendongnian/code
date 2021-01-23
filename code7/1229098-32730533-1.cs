    public class IntegerTextBox : TextBox
    {
        private const int ES_NUMBER = 0x2000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | ES_NUMBER;
                return cp;
            }
        }
    }
