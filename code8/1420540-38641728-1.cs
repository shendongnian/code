          protected void UploadFile(object sender, EventArgs e)
            {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
                {
                using (BinaryReader br = new BinaryReader(fs))
                    {
                    System.Drawing.Image imagetuUpload = System.Drawing.Image.FromStream(fs);
                    Bitmap bitmap = new Bitmap(imagetuUpload);
                    System.IO.MemoryStream stream = new MemoryStream();
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    stream.Position = 0;
                    byte[] upproimag = new byte[stream.Length + 1];
                    stream.Read(upproimag, 0, upproimag.Length);
          
                    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                        {
                        string query = "INSERT INTO foto(FileName, ContentType, Content) VALUES (@FileName, @ContentType, @Content)";
                        using (MySqlCommand cmd = new MySqlCommand(query))
                            {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@FileName", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Content", upproimag);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            }
                        }
                    }
                }
            Response.Redirect(Request.Url.AbsoluteUri);
            }
