            using (WebClient client = new WebClient())
            {
                byte[] imageData = client.DownloadData(filePath);
                string contentType = "";
                if (fileName.ToLower().Contains(".png"))
                {
                    contentType = "Images/png";
                }
                else if (fileName.ToLower().Contains(".jpg"))
                {
                    contentType = "Images/jpg";
                }
                else if (fileName.ToLower().Contains(".jpeg"))
                {
                    contentType = "Images/jpeg";
                }
                else if (fileName.ToLower().Contains(".pdf"))
                {
                    contentType = "Images/pdf";
                }
                else if (fileName.ToLower().Contains(".tiff"))
                {
                    contentType = "Images/tiff";
                }
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.ContentType = "image/JPEG";
                Response.OutputStream.Write(imageData, 0, imageData.Length);
                Response.End();
            }
            return new EmptyResult();
        }
