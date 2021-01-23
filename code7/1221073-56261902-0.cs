                using (var image = Image.Load(fileData)) // fileData could be file path or byte array etc.
                {
                    var h = image.Size().Height / 2;
                    var w = image.Size().Width / 2;
                    var options = new ResizeOptions
                    {
                        Mode = ResizeMode.Stretch,
                        Size = new Size(w, h)
                    };
                    image.Mutate(_ => _.Resize(options));
                    using (var destStream = new MemoryStream())
                    {
                        var encoder = new JpegEncoder();
                        image.Save(destStream, encoder);
                        // Do something with output stream
                    }     
                }
