    protected void btnCapture_Click(object sender, EventArgs e)
    {
        if (Request.InputStream.Length > 0)
            {
                using (StreamReader reader = new StreamReader(Request.InputStream))
                {
                    string hexString = Server.UrlEncode(reader.ReadToEnd());
                    string imageName = DateTime.Now.ToString("dd-MM-yy hh-mm-ss");
                    string imagePath = string.Format("~/losefound/{0}.png", imageName);
                    string ItemName = txtItemName.Text;
                    string Place = txtPlace.Text;
                    byte[] bytes = ConvertHexToBytes(hexString);
                    File.WriteAllBytes(Server.MapPath(imagePath), bytes);
                    string VisitorManagementConnectionString = ConfigurationManager.ConnectionStrings["VisitorManagementConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(VisitorManagementConnectionString))
                    {
                        string query = "INSERT INTO LostFound (ItemName, FoundAt, TimeIn, ImageName, ContentType, Data) VALUES(@ItemName, @FoundAt, @TimeIn, @ImageName, @ContentType, @Data);SELECT SCOPE_IDENTITY()";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@ItemName", ItemName);
                            cmd.Parameters.AddWithValue("@FoundAt", Place);
                            cmd.Parameters.AddWithValue("@TimeIn", DateTime.Now);
                            cmd.Parameters.AddWithValue("@ImageName", imageName);
                            cmd.Parameters.AddWithValue("@ContentType", "image/png");
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            con.Open();
    
                            Session["CapturedImageId"] = cmd.ExecuteScalar();
    
                            con.Close();
    
                        }
                    }
                }
            }
    }  
