         string strImageName = txtImage.Text.ToString();      //to store image into sql database.
           
                    if (FileUpload1.PostedFile != null &&
                    FileUpload1.PostedFile.FileName != "")
                      {
                           byte[] imageSize = new byte[FileUpload1.PostedFile.ContentLength];
                           HttpPostedFile uploadedImage = FileUpload1.PostedFile;
                           uploadedImage.InputStream.Read(imageSize, 0, (int)FileUpload1.PostedFile.ContentLength);
                    // Create SQL Command 
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO Pictures(ID,ImageName,Image)" +
                               " VALUES (@ID,@ImageName,@Image)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    //retrieve latest ID from tables which was stored in session.
                    int ID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ID"].ToString());
                    SqlParameter ID = new SqlParameter
                                ("@ID", SqlDbType.Int, 5);
                    ID.Value = (Int32)ID;
                    cmd.Parameters.Add(ID);
                    SqlParameter ImageName = new SqlParameter
                                ("@ImageName", SqlDbType.VarChar, 50);
                    ImageName.Value = strImageName.ToString();
                    cmd.Parameters.Add(ImageName);
                    SqlParameter UploadedImage = new SqlParameter("@Image", SqlDbType.Image, imageSize.Length);
                    UploadedImage.Value = imageSize;
                    cmd.Parameters.Add(UploadedImage);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result > 0)
                        lblMessage.Text = "File Uploaded";
                    lblSuccess.Text = "Successful !";
                
      }}
