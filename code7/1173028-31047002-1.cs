        public ActionResult MySaveAction(string datauri)
        {
            // Some stuff.
            if (datauri.Length > 0)
            {
                Byte[] bitmapData = new Byte[datauri.Length];
                bitmapData = Convert.FromBase64String(FixBase64ForImage(datauri));
                
                string fileLocationImageName = "C:/MYIMAGE.JPG";
                MemoryStream ms = new MemoryStream(bitmapData);
                using (Bitmap bitImage = new Bitmap((Bitmap)Image.FromStream(ms)))
                {
                    bitImage.Save(fileLocationImageName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    output = fileLocationImageName;
                }
            }
            return Json(output, JsonRequestBehavior.AllowGet);
        }
