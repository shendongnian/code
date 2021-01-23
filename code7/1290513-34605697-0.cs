     byte[] fileContents = (byte[])dts.Rows[0]["image"];
        var memoryStream = new MemoryStream(fileContents);
                    var biId = new Bitmap(memoryStream);
                    Bitmap bitMapImage = new System.Drawing.Bitmap(biId);   
                    Graphics graphicImage = Graphics.FromImage(bitMapImage);
                    graphicImage.SmoothingMode = SmoothingMode.HighQuality;
                    SolidBrush blueBrush = new SolidBrush(Color.Blue);
                    SolidBrush redBrush = new SolidBrush(Color.Red);
                    SolidBrush greenBrush = new SolidBrush(Color.Green);       
                    RectangleF yourtextmessage= new RectangleF(285, 20, 250, 250);
                   
                    
                        graphicImage.DrawString(dts.Rows[0]["text1"].ToString() + " ,", new Font("Verdana", 12, FontStyle.Italic), Brushes.White, yourtextmessage);
                       
                          
                    context.Response.ContentType = "image/jpeg";
                    bitMapImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    graphicImage.Dispose();
                    bitMapImage.Dispose();
