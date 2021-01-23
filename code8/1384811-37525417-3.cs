    CREATE TABLE [dbo].[Image_table](   
    
    	[Id] [int] IDENTITY(1,1) NOT NULL,
    	[image]     VARBINARY (MAX) NULL
    	)
 
    protected void Button1_Click(object sender, EventArgs e)
        {
            Stream fs = FileUpload.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
    
             string consString = ConfigurationManager.ConnectionStrings["connectionKey"].ConnectionString;
             SqlConnection con = new SqlConnection(consString);
            
                try
                { 
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into [dbo].[Image_table]  values (@img)";
                    cmd.Parameters.Add("@img", SqlDbType.Image).Value = bytes;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                  
                }
                catch (Exception ex)
                {
                    throw ex;
                }
             
        }  
  
               
