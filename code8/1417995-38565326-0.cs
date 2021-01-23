    public string UserName
        {
            get
            {
                return txtUserName.Text;
            }
            set
            {
                txtUserName.TextChanged -= txtUserName_TextChanged;
                txtUserName.Text = value;
                txtUserName.TextChanged -= txtUserName_TextChanged;
            }
        }
