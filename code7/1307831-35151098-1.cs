    internal class Program
    {
        private static readonly List<BarcodeFormat>  Fmts = new List<BarcodeFormat> { BarcodeFormat.All_1D };
        
        static void Main(string[] args)
        {
            Bitmap originalBitmap = new Bitmap(@"C:\Users\me\Desktop\6.jpg");
            Bitmap img = CropImage(originalBitmap, new Rectangle(0 , 0, originalBitmap.Width, originalBitmap.Height));
            int width = img.Width;
            int heigth = img.Height;
            int nbOfFrames = 1;
            bool found = false;
            while (!found && width > 10 && heigth > 10)
            {
                if (DecodeImg(img))
                {
                    break;
                }
                nbOfFrames *= 4;
                width /= 2;
                heigth /= 2;
                var x = 0;
                var y = 0;
                for (int i = 0; i < nbOfFrames; i++)
                {
                    img.Dispose();
                    img = new Bitmap(CropImage(originalBitmap, new Rectangle(x, y, width, heigth)));
                    if (DecodeImg(img))
                    {
                        found = true;
                    }
                    x += width;
                    if (x < originalBitmap.Width)
                    {
                        continue;
                    }
                    x = 0;
                    y += heigth;
                    if (y >= originalBitmap.Height)
                    {
                        y = 0;
                    }
                }
            }
            
        }
        public static Bitmap CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, PixelFormat.Format24bppRgb);
        }
        public static bool DecodeImg(Bitmap img)
        {
            BarcodeReader reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options =
                {
                    PossibleFormats = Fmts,
                    TryHarder = true,
                    ReturnCodabarStartEnd = true,
                    PureBarcode = false
                }
            };
            Result result = reader.Decode(img);
            if (result != null)
            {
                Console.WriteLine(result.BarcodeFormat);
                Console.WriteLine(result.Text);
                return true;
            }
            Console.Out.WriteLine("Raté");
            return false;
        }
    }
