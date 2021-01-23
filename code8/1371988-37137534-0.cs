            protected void btnAdd_Click(object sender, EventArgs e)
            {
                if (Request.Files.Count > 0)
                {
                    HttpFileCollection attachments = Request.Files;
                    for (int i = 0; i < attachments.Count; i++)
                    {
                        HttpPostedFile attachment = attachments[i];
                        if (attachment.ContentLength > 0 && !String.IsNullOrEmpty(attachment.FileName))
                        {
                            string fname = attachment.FileName;
                            string path = Server.MapPath("~/EventPics/");
                            string fext = Path.GetExtension(fname);
                            fext = fext.ToLower();
                            string link = "~/EventPics/" + fname;
                            if (fext == ".jpg" || fext == ".png" || fext == ".gif" || fext == ".bmp")
                            {
                                attachment.SaveAs(path + fname);
                                con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAAERT_DBConnectionString"].ConnectionString);
                                SqlCommand cmd;
    
                                //create command
                                cmd = new SqlCommand("EventMasterInsert", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ImagePath", link);
                                cmd.Parameters.AddWithValue("@EventTitle", txtEventTitle.Text);
                                cmd.Parameters.AddWithValue("@EventDate", txtEventDate.Text);
                                cmd.Parameters.AddWithValue("@EventPlace", txtPlace.Text);
                                cmd.Parameters.AddWithValue("@ShortDescription", txtShort.Text);
                                cmd.Parameters.AddWithValue("@Description", txtDesc.Text);
                                cmd.Parameters.AddWithValue("@EventTime", txtTime.Text);
                                //open connection
                                cmd.Connection = con;
                                con.Open();
    
                                //execute command
                                int rowcount = cmd.ExecuteNonQuery();
                                if (rowcount > 0)
                                {
                                    Response.Write("<script>alert('Event Added');</script>");
                                    txtDesc.Text = "";
                                    txtEventDate.Text = "";
                                    txtEventTitle.Text = "";
                                    txtPlace.Text = "";
                                    txtShort.Text = "";
                                    txtTime.Text = "";
    
    
                                }
                            }
                        }
                    }
                }
            }
