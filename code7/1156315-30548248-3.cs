                        int footerHeight = 30;
                        Bitmap bitmapImg = new Bitmap(img);// Original Image
                        Bitmap bitmapComment = new Bitmap(img.Width, footerHeight);// Footer
                        Bitmap bitmapNewImage = new Bitmap(img.Width, img.Height + footerHeight);//New Image
                        Graphics graphicImage = Graphics.FromImage(bitmapNewImage);
                        graphicImage.Clear(Color.White);
                        graphicImage.DrawImage(bitmapImg, new Point(0, 0));
                        graphicImage.DrawImage(bitmapComment, new Point(bitmapComment.Width, 0));
                        graphicImage.DrawString("Hi, This is Vivek !", new Font("Arial", 15), new SolidBrush(Color.Black), 0, bitmapImg.Height + footerHeight / 6);
                        bitmapNewImage.Save(yourImagePath);
                        bitmapImg.Dispose();
                        bitmapComment.Dispose();
                        bitmapNewImage.Dispose();
