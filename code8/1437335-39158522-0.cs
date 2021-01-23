    protected void Button1_Click(object sender, EventArgs e)
    {
        Registration.Registration reg = new Registration.Registration();    //Declare object of Registration class here
        reg.Name = txtName.Text;
        reg.Age = txtAge.Text;
        reg.Sex = txtSex.Text;
        reg.Address = txtAddress.Text;
        reg.Email = txtEmail.Text;
        reg.Phone = txtPhone.Text;
        reg.InsertRegistration();
        phSuccess.Visible = true;
    }
