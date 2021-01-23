            Byte[] imgByte = null;
            System.IO.Stream strm;
            string imgfile = System.IO.Path.GetFileName(FileUpload1.FileName);
            string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (ext == ".jpg" | ext == ".jpeg" | ext == ".gif" | ext == ".png")
            {
                try
                {
                    if (FileUpload1.HasFile && FileUpload1.PostedFile != null)
                    {
                        int fileLen = FileUpload1.PostedFile.ContentLength;
                        HttpPostedFile File = FileUpload1.PostedFile;
                        StringBuilder sb = new StringBuilder();
                        imgByte = new Byte[fileLen];
                        strm = FileUpload1.FileContent;
                        strm.Read(imgByte, 0, fileLen);
                    }
                }
                catch (Exception ex)
                {
                    Label1.Text = "Stream: " + ex.ToString();
                }
                if (imgByte != null)
                {
                    try
                    {
                        string connStr = ConfigurationManager.ConnectionStrings["imgContext"].ConnectionString;
                        string cmdStr = "INSERT INTO [Table] (filename, image) VALUES (@filename, @image);";
                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
                            {
                                conn.Open();
                                cmd.Parameters.AddWithValue("@filename", imgfile);
                                cmd.Parameters.AddWithValue("@image", imgByte);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                cmd.Dispose();
                                conn.Dispose();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Label2.Text = "sql: " + ex.ToString();
                    }
                }
