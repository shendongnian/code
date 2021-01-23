    using (conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=""C:\Users\BOB\Documents\Visual Studio 2012\Projects\Login\Login\Student_Marks.mdf"";Integrated Security=True"))//; this was the issue
    {
         using (adap = new SqlDataAdapter("select * from tbl_Students_Marks", conn))
         {
              DataSet das = new DataSet();
              adap.Fill(das);
              dataGridView1.DataSource = das.Tables[0];//this must be das not ds
         }
    }
