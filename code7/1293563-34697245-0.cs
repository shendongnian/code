    private void btn_guardian_student_search_Click(object sender, EventArgs e)
    {
        if (rd_btn_guardian_student_no.Checked == true)
        {
            using(SqlConnection cnn = new SqlConnection(......))
            using(SqlCommand cmd = new SqlCommand(@"SELECT * FROM Guardian 
                                       WHERE STUDENT_NO = @student_no", cnn))
            {
               cnn.Open();
               cnn.Add("@student_no", SqlDbType.Int).Value = Convert.ToInt32(txt_bx_guardian_student_search.Text);
               using(SqlDataReader rd = new cmd.ExecuteReader())
               {
                   if(!rd.HasRows)
                      lbl_guardian_student_search.Text = "No Guardian record exists for this student. Please enter the Guardian Information";
                   else
                   {
                      rdr.Read();
                      txtBox1.Text = rdr.Item["DBFieldName1"].ToString();
                      txtBox2.Text = rdr.Item["DBFieldName2"].ToString();
                   }
               }                
           }
       }
    }
