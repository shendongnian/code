    if(chkAttachments.Text.Contains(".jpg"))
            {
                var selectedImage = chkAttachments.Text;
                picAttachPreview.Image = Image.FromFile(tempfolder + @"\" + selectedImage);
            }
