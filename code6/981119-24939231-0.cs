        private void LoadPictures()
        {
            foreach (string strFileName in Directory.GetFiles(Server.MapPath("~/path/")))
            {
                ImageButton imageButton = new ImageButton();
                FileInfo fileInfo = new FileInfo(strFileName);
                imageButton.ImageUrl = "~/path/" + fileInfo.Name.ToString();
                imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                imageButton.ID = Path.GetFileName(strFileName);
                photos.Controls.Add(imageButton);
                //imageButton.Attributes.Add("ID", strFileName);
                //imageButton.Attributes.Add("class", "imgOne");
                //imageButton.Attributes.Add("runat", "server");
                //imageButton.Attributes.Add("OnClick", "toImageDisplay");
            }
        }
        void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            //your code...
        }
