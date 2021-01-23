    using (MySqlConnection con = new MySqlConnection(connString))
    {
        string stm = "Insert into  Tbl_Sud_Details(Name,Course,DateofAdmission)Values(@Name,@Course,@DateofAdmission)";
        using (SqlCommand cmd = new SqlCommand(stm))
        {
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = ddlname.SelectedItem.Text;
            cmd.Parameters.Add("@Course", SqlDbType.VarChar).Value = txtcourse.Text;
            cmd.Parameters.Add("@DateofAdmission", SqlDbType.DateTime).Value = Convert.ToDateTime(txtAdddate.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
