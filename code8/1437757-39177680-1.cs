      protected void Button1_Click(object sender, EventArgs e)
        {
            var reg = new Registration.Registration
            {
                Name = txtName.Text,
                Age = Int32.Parse(txtAge.Text),
                Sex = txtSex.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                Phone = Int32.Parse(txtPhone.Text)
            };
    
            this.InsertRegistration(reg);
            phSuccess.Visible = true;
        }
    
        public void InsertRegistration(Registration.Registration reg)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("dbo.Procedure", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
    
                        var parameterName = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                        var parameterAge = new SqlParameter("@Age", SqlDbType.VarChar, 50);
                        var parameterSex = new SqlParameter("@Sex", SqlDbType.VarChar, 50);
                        var parameterAddress = new SqlParameter("@Address", SqlDbType.VarChar, 50);
                        var parameterEmail = new SqlParameter("@Email", SqlDbType.VarChar, 100);
                        var parameterPhone = new SqlParameter("@Phone", SqlDbType.VarChar, 100);
    
                        parameterName.Value = reg.Sex;
                        parameterAge.Value = reg.Age;
                        parameterSex.Value = reg.Email;
                        parameterAddress.Value = reg.Address;
                        parameterEmail.Value = reg.Email;
                        parameterPhone.Value = reg.Phone;
    
                        cmd.Parameters.Add(parameterName);
                        cmd.Parameters.Add(parameterAge);
                        cmd.Parameters.Add(parameterSex);
                        cmd.Parameters.Add(parameterAddress);
                        cmd.Parameters.Add(parameterEmail);
                        cmd.Parameters.Add(parameterPhone);
    
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
