    private void Biodata_Load(object sender, EventArgs e)
    {
        this.ActiveControl = tbName;
        tbName.Focus();
        Display(); //                               |
        //                                          v Here
        LoggedAs.Text = "You are logged in as: " + User;
        if (Role != "Admin\t")
        {
            btnDelete.Enabled = false;
        }
    }
