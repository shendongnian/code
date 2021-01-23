    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string db = DropDownList1.SelectedItem.Value + "-" + DropDownList2.SelectedItem.Value + "-" + DropDownList3.SelectedItem.Value;
        using(SqlConnection con = new SqlConnection("data source=BAN095\\SQLEXPRESS; database=Reg-DB; integrated security=SSPI"))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("insert into Reg(FirstName,LastName,EmailID,PhoneNum,Gender,DOB)values(@FirstName,@LastName,@Email,@Mobile,@Gender,@Db)", con))
            {
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                //Do the same with other parameters
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601)
                    {
                        // Duplicate key! Do whatever you want
                    }
                }
            }
        }
    } 
