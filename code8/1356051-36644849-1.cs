                string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
                byte[] bytes = Convert.FromBase64String(base64);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                string folderPath = Server.MapPath("~/Images/");  //Create a Folder in your Root directory on your solution.
                string fileName = "IMageName" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".jpg";
                string imagePath = folderPath + fileName;
                img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
