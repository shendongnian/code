        protected void Upload(object sender, EventArgs e)
        {
            //Upload and save the file
            string csvPath = Server.MapPath("~/Temp/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);
            string consString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.Transaction = tran;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "your_sp_name_here";
                    cmd.Parameters.Add(new SqlParameter("@title",System.Data.SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@artist", System.Data.SqlDbType.NVarChar));
                    // other parameters follow
                    // ...
                    string csvData = File.ReadAllText(csvPath);
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            // for every row call the command and fill in the parameters with proper values
                            cmd.Parameters["@title"].Value = row[0];
                            cmd.Parameters["@artist"].Value = row[1];
                            // ...
                            cmd.ExecuteNonQuery();
                        }
                    }
                    // when done commit the transaction
                    tran.Commit();
                }
            }
        }
