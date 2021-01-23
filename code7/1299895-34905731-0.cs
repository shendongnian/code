    string svrConnection = "Server=.\\sqlexpress;Database="+db+";User ID=user;Password=password;"; 
    Directory.CreateDirectory("C:\\" + db + "\\");
    FileInfo file = new FileInfo("C:\\script.sql");
    string PCS = file.OpenText().ReadToEnd();
    
    try
    {
        using (SqlConnection con = new SqlConnection(svrConnection))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(PCS, con))
            {
                cmd.ExecuteNonQuery();
                using (SqlDataReader pcsrdr = cmd.ExecuteReader())
                using (StreamWriter PCSLog = new StreamWriter("C:\\" + db + "\\Log" + db + ".txt"))
                {
                    while (pcsrdr.Read())
                        PCSLog.WriteLine(pcsrdr[0].ToString() + pcsrdr[1].ToString() + ",");
                    PCSLog.Close();
                }
                
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Can not open connection !", ex.Message);
    }  
