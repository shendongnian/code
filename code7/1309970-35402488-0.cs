     private static byte[] SvgImageHandler(string svgContent)
            {
                if (svgContent.Contains("http://www.w3.org/2000/svg"))
                {
                    var svgByteAry = Encoding.UTF8.GetBytes(svgContent);
                    using (var stream = new MemoryStream(svgByteAry))
                    {
                        var svgDocument = SvgDocument.Open<SvgDocument>(stream);
                        using (var memoryStream = new MemoryStream())
                        {
                            svgDocument.Draw()
                                       .Save(memoryStream, ImageFormat.Png);
                            var byteArray = memoryStream.ToArray();
                            return byteArray;
                        }
                    }
                }
                //Skip if not url based image
                if (!Uri.IsWellFormedUriString(svgContent, UriKind.RelativeOrAbsolute))
                    return null;
    
                if (!ValidateUrlImage(svgContent))
                {
                    ICacheService cacheService = new HttpCache();
                    return cacheService.Get(Constants.NoImage,
                                            () =>
                                            {
                                                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings[Constants.ImagePath];
                                                var defaultUrl = Path.Combine(baseDirectory, Constants.NoImageFile);
                                                var img = Image.FromFile(defaultUrl);
                                                var imgCon = new ImageConverter();
                                                return (byte[])imgCon.ConvertTo(img, typeof(byte[]));
                                            });
                }
                return null;
            }
