    public partial class UserTextBox : UserControl
    {
        public string OnBlur {get;set;} // add the property for onblur
        protected void Page_Load(object sender, EventArgs e) // or can be on init
        {
            txtUserName.OnBlur = OnBlur;
        }
    }
