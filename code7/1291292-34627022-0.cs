     try
                {
                    var request = WebRequest.Create(String.Format(url + "?t=webwx&_={0}", timestamp));
    
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            Image image = Image.FromStream(stream);
                            qe_img.Image = image;
                            qe_img.Height = image.Height;
                            qe_img.Width = image.Width;
    
    
                        }
                    }
    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
