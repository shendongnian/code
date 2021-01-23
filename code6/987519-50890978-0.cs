    What worked for me is below code on button click event:
 
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox checkboxdelete = (CheckBox)row.FindControl("checkboxdelete");
            if (checkboxdelete.Checked == true)
            {
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
                {
                    scon.Open();
                    Label LblId = (Label)row.FindControl("rollno");
                    int rollno = Convert.ToInt32(LblId.Text);
                    SqlCommand scmd = new SqlCommand("delete from student where rollno = @rollno", scon);
                    scmd.Parameters.AddWithValue("@rollno", rollno);
                    scmd.ExecuteNonQuery();
                    scon.Close();
                    BindGrid();
                    Label4.Text = "";
                }
            }
            else
            {
                Label4.Text = "No record is selected to delete !";
                Label4.ForeColor = System.Drawing.Color.Red;
            }
        } 
