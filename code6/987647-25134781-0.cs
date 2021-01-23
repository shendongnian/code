    protected void Button3_Click(object sender, EventArgs e)
    {
        int rows = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox checkbox1 = (CheckBox)row.FindControl("checkboxdelete");
            if (checkbox1.Checked)
            {
                int rollno = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value.ToString());
                //CheckBox checkbox1 = (CheckBox)row.FindControl("checkbox1");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                SqlCommand cmd = new SqlCommand("delete from student where rollno = @rollno ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@rollno", SqlDbType.Int).Value = rollno.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                rows++;
            }
        }
        grd_bnd();
        MessageBox.Show(String.Format("Rows affected {0}", rows);
    }
