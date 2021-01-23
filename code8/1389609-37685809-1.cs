    protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileuploadImage.HasFile)
            {
                //getting length of uploaded file
                int length = fileuploadImage.PostedFile.ContentLength;
                //create a byte array to store the binary image data
                byte[] imgbyte = new byte[length];
                //store the currently selected file in memeory
                HttpPostedFile img = fileuploadImage.PostedFile;
                //set the binary data
                img.InputStream.Read(imgbyte, 0, length);
                string imagename = txtImageName.Text;
                //use the web.config to store the connection string
                SqlConnection connection = new SqlConnection(strcon);
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Image (ImageName,Image) VALUES (@imagename,@imagedata)", connection);
                cmd.Parameters.Add("@imagename", SqlDbType.VarChar, 50).Value = imagename;
                cmd.Parameters.Add("@imagedata", SqlDbType.Image).Value = imgbyte;
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                if (count == 1)
                {
                    BindGridData();
                    txtImageName.Text = string.Empty;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('" + imagename + " image inserted successfully')", true);
                }
            }
        }
        private void BindGridData()
        {
            SqlConnection connection = new SqlConnection(strcon);
            SqlCommand command = new SqlCommand("SELECT imagename,ImageID from [Image]", connection);
            SqlDataAdapter daimages = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            daimages.Fill(dt);
            gvImages.DataSource = dt;
            gvImages.DataBind();
            gvImages.Attributes.Add("bordercolor", "black");
        }
