    public MainForm(int userType) { // u pass userType when creating the form after the login
        if (userType == 1) { 
            this.superButton.Visible = true; //by default superButton would be hidden
        }
    }
