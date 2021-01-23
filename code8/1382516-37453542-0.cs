    Image img = Image.FromFile(@"C:\a.png");
                byte[] arr;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    arr = ms.ToArray();
                }
                using (var ms = new System.IO.MemoryStream(arr))
                {
                    using (var img1 = Image.FromStream(ms,false,true)) // error thrown here as 'parameter is not valid'
                    {
                        img1.Save("D:\\anyFileName.png", ImageFormat.Png);
                    }
                }
