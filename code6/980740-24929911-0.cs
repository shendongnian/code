    protected void uploadFile_Click(object sender, EventArgs e)
         {
    
           if (UploadImages.PostedFile != null)
    
           {
    
               string strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; 
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            try
            {             
    
               foreach (HttpPostedFile uploadedFile in this.UploadImages.PostedFiles)
               {
                    string newname = System.DateTime.Now.ToString("yyMMdd-hhmmss-") + uploadedFile.FileName;
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("/Images/Editors/BG/"), newname));
                    listofuploadedfiles.Text += string.Format("<br /><img width='100px' src='/Images/Editors/BG/{0}'/>{0}<br clear='all'/>", newname);
    
    
    			  SqlCommand cmd = new SqlCommand();
    			  cmd.Connection = con;
    			  cmd.CommandType = CommandType.Text;
    			  cmd.CommandText = @"INSERT INTO BackgroundImages(BG_fileName, IDuser)
     			  VALUES(@param1,@param2)";  
    
    			  cmd.Parameters.AddWithValue("@param1", newname);  
    			  cmd.Parameters.AddWithValue("@param2", HttpContext.Current.User.Identity.GetUserId());
    			  cmd.ExecuteNonQuery();  
               }
            }
            catch (Exception ex)
            {
                Response.Write("Error while inserting record on table..." + ex.Message + "Insert Records");
            }
            finally
            {
                con.Close();
                con.Dispose();
    
             }
    
            }
    
       }
