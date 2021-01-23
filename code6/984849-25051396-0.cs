        public static string WriteImage(string data, string imgPath)
        {
            try
            {
                data = "*" + data + "*";
                using (var dummyBitmap = new Bitmap(1, 1))
                using (var threeOfNine = new Font("IDAutomationHC39M", 60, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point))
                {
                    SizeF dataSize;
                    using (var graphics = Graphics.FromImage(dummyBitmap))
                    {
                        dataSize = graphics.MeasureString(data, threeOfNine);
                    }
                    using (var barcode = new Bitmap(dummyBitmap, dataSize.ToSize()))
                    using (var graphics = Graphics.FromImage(barcode))
                    using (var brush = new SolidBrush(Color.Black))
                    {
                        graphics.Clear(Color.White);
                        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                        graphics.DrawString(data, threeOfNine, brush, 0, 0);
                        graphics.Flush();
                        barcode.SetResolution(300, 300);
                        barcode.Save(imgPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return imgPath.Substring(imgPath.LastIndexOf("\\") + 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving string \"" + data + "\" to a bitmap at location: " + imgPath);
                Debug.WriteLine(ex.ToString());
                return "";
            }
        }
