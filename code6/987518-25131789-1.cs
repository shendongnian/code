           for (int i = 0; i < GridView1.Rows.Count; i++)
           {
            CheckBox checkboxdelete = ((CheckBox)GridView1.Rows[i].FindControl("checkboxdelete"));
            if (checkboxdelete.Checked == true)
            {
                Label lblrollno = ((Label)GridView1.Rows[i].FindControl("lblrollno"));
                int rolNo = Convert.ToInt32(lblrollno.Text);
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                SqlCommand cmd = new SqlCommand("delete from student where rollno = @rollno ", con);
                cmd.CommandType = CommandType.Text;
                SqlParameter param = new SqlParameter("@rollno", SqlDbType.Int);
                param.Value = rolNo;
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
            }
          } 
