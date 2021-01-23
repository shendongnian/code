        public partial class CustomCheckBox : System.Web.UI.UserControl
        {
            public event EventHandler<CheckBoxEventArgs> CheckChanged;
    
            public string ValueOne { get; set; }
            public string ValueTwo { get; set; }
    
            public string Text
            {
                get { return chkCheckBox.Text; }
                set { chkCheckBox.Text = value; }
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void chkCheckBox_CheckedChanged(object sender, EventArgs e)
            {
                if (CheckChanged != null)
                {
                    var args = new CheckBoxEventArgs()
                    {
                        ValueOne = this.ValueOne,
                        ValueTwo = this.ValueTwo
                    };
                    CheckChanged(this, args);
                }
            }
    }
