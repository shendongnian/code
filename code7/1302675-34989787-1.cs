    if (txtPassword.Text == "10")
    {
        FormMenu a = new FormMenu();
        this.Hide();
        a.EmployeManagement.Enabled = true;
        a.Sabtenam.Enabled = true;
        a.Shora.Enabled = true;
        a.HozorGhiab.Enabled = true;
        a.Ketabkhane.Enabled = true;
        a.Show();
