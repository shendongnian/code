    foreach (string strFileName in Directory.GetFiles(Server.MapPath("~/path/")))
    {
           ImageButton imageButton = new ImageButton();
           FileInfo fileInfo = new FileInfo(strFileName);
           imageButton.ImageUrl = "~/path/" + fileInfo.Name.ToString();
           imageButton.Attributes.Add("ID" , strFileName);                                  
           imageButton.Click += Unnamed1_Click;
           photos.Controls.Add(imageButton);
    }
