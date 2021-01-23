    [System.ComponentModel.DesignerCategory("Code")]
    public class MyTextBox : TextBox
    {
        [Browsable(false)]
        public int AsInt
        {
            get
            {
                int result;
                int.TryParse(Text, out result);
                return result;
            }
        }
        [Browsable(false)]
        public bool IsIntOk
        {
            get
            {
                int result;
                return int.TryParse(Text, out result);
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            ForeColor = IsIntOk ? SystemColors.WindowText : Color.Red;
            base.OnTextChanged(e);
        }
    }
