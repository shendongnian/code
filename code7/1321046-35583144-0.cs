    protected void button7_Click(object sender, EventArgs e)
        {
	    string connectionstring;
        
        connectionstring = """data source=D7010-H14NBZ1\\SQLEXPRESS;initial catalog=iTest;user id=TestUser;password=testPW;";
	    
        string query = "SELECT Appeal, Member_ID, Amount, DateGiven FROM  dbo.Appeals WHERE Appeal IN (N'6Y', N'7G', N'WR') ORDER BY Appeal DESC";
            
        SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            using (SqlDataAdapter a = new SqlDataAdapter(command))
            {
                a.Fill(data);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(data, "Excel Export");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Excel Export.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
	}
