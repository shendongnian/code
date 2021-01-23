    public Label LoginLabelText
    {
        get { return this.loginLabel.Text; }
        set { this.loginLabel.Text = value; }
    }
    ((YourMasterPageClass)Master).LoginLabelText = "Welcome!";
