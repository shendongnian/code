        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = Request.QueryString["Email"];
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Job (Industry, JobPosition, ExactAddress, Region, Salary, JobDesc, EmployerID) VALUES (@industry, @jobPosition, @exactAddress, @region, @salary, @jobDesc, (Select employerid from employer where email = @email))";
            cmd.Parameters.Add("@industry", SqlDbType.VarChar, 255).Value = Industry.SelectedValue.ToString();
            cmd.Parameters.Add("@jobPosition", SqlDbType.VarChar, 255).Value = TextBox3.Text;
            cmd.Parameters.Add("@exactAddress", SqlDbType.VarChar, 255).Value = TextBox5.Text;
            cmd.Parameters.Add("@region", SqlDbType.VarChar, 255).Value = Region.SelectedValue.ToString();
            cmd.Parameters.Add("@salary", SqlDbType.VarChar, 255).Value = TextBox6.Text;
            cmd.Parameters.Add("@jobDesc", SqlDbType.VarChar, 255).Value = TextBox7.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 255).Value = email.ToString();
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd.Parameters.Clear();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Job Posted!');</script>");
            Response.Redirect("EmployerProfile.aspx");
        }
