               try
                {
                    var img = new BitmapImage(new Uri("url?ID_IMMAGINE=" + idImg1 + "&HEIGHT=100", UriKind.Absolute));
                    if (img == null)
                    {
                        img = new BitmapImage(new Uri("defaultImage.png",UriKind.RelativeOrAbsolute));
                    }
                }
                catch
                {
                    img = new BitmapImage(new Uri("defaultImage.png", UriKind.RelativeOrAbsolute));
                }
