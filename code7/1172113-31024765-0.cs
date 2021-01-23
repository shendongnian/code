    public static void LoadImage()
        {
            try
            {
                //get a temp image from bytes, instead of loading from disk
                //data:image/gif;base64,
                //this image is a single pixel (black)
                byte[] bytes = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==");
                Image image;
                Bitmap bimage;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                }
                bimage = new Bitmap(image);
                bimage.Save("c:\\img.gif", System.Drawing.Imaging.ImageFormat.Gif);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
