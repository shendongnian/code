     NpgsqlConnection conn = new NpgsqlConnection("Server=192.166.0.121;User  Id=trh; " + "Password=trh;Database=checking_DB;"); 
     conn.Open();
     DataTable dt = new DataTable();
     string command = "select Id,Name from tbl_Names";
     using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(command, conn))
     {
             Adpt.Fill(dt);
             foreach(DataRow row in dt.Rows)
			 { 
				Label lblSno = new Label();
				Label lblProfitCenter = new Label();
				lblSno.Text = row[0].ToString();
				lblProfitCenter.Text = row[1].ToString(); 
                Panel1.Controls.Add(lblSno);
				Panel1.Controls.Add(lblProfitCenter);
			}
     }
