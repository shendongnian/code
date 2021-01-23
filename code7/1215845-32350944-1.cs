            HttpFileCollection fileCollection = Request.Files;
            string fileName = "";
            for (int i = 0; i < fileCollection.Count; i++) {
                HttpPostedFile uploadfile = fileCollection[i];
                fileName = Path.GetFileName(uploadfile.FileName);
                if (uploadfile.ContentLength > 0) {
                    uploadfile.SaveAs(Server.MapPath("~/Photo-Upload-Large/") + fileName);
                    lblMessage.Text += fileName + "Saved Successfully<br>";
                    //Store Crope Image
                    System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath("~/Photo-Upload-Large/") + fileName);
                    int newwidthimg = 400;
                    float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
                    int newHeight = Convert.ToInt32(newwidthimg / AspectRatio);
                    Bitmap thumbnailBitmap = new Bitmap(newwidthimg, newHeight);
                    Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
                    thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new Rectangle(0, 0, newwidthimg, newHeight);
                    thumbnailGraph.DrawImage(image, imageRectangle);
                    thumbnailBitmap.Save(Server.MapPath("~/Photo-Upload-Thumb/"), ImageFormat.Jpeg);
                    thumbnailGraph.Dispose();
                    thumbnailBitmap.Dispose();
                    image.Dispose();     
                }
            }
            int _Itm_Id = GetMaxNo();
            if (_Itm_Id > 0) {
                ConnectDataBase();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GENERAL";
                cmd.Parameters.AddWithValue("@SP_STATUS", "INSERT_ITM");
                cmd.Parameters.AddWithValue("@ITM_ID", _Itm_Id);
                cmd.Parameters.AddWithValue("@ITM_CAT_ID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@ITM_NAME", txtItemName.Text);
                cmd.Parameters.AddWithValue("@ITM_PATH", fileName);
                cmd.Parameters.AddWithValue("@ITM_LARGE", fileName);
                //cmd.Parameters.AddWithValue("@ITM_PRICE", Convert.ToDecimal(txtPrice.Text));
                int retval = cmd.ExecuteNonQuery();
                if (retval > 0)
                    lblMessage.Text = "Record Successfully Inserted!!!";
                else
                    lblMessage.Text = "Server Error!!! Please Try Again...";
                ClearAll();
            }
        }
