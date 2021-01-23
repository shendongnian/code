    protected void Button1_Click(object sender, EventArgs e)
    {
    
        //Add this part
        Registration reg = new Registration();
    
        reg.Name = txtName.Text;
        reg.Age = txtAge.Text;
        reg.Sex = txtSex.Text;
        reg.Address = txtAddress.Text;
        reg.Email = txtEmail.Text;
        reg.Phone = txtPhone.Text;
        reg.InsertRegistration();
        phSuccess.Visible = true;
    }
