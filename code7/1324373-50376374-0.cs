    Project Console Export Psd to Jpg
    public class Tamanho
    {
        public string NameFolder { get; set; }
        public int Width { get; set; }
        public int  Heigth { get; set; }
        public string ImagePath { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var PathDefault = @"C:\FOTOSZSA";
            DirectoryInfo di1 = new DirectoryInfo(PathDefault);
            string strPath = @"c:\ImagensImport\LogErro.txt";
            File.Create(strPath).Dispose();
            if (!di1.Exists)
            {
                Directory.CreateDirectory(PathDefault);
            }
            Tamanho settings = new Tamanho { NameFolder = "1000x1000", Width = 1000, Heigth = 1000, ImagePath = @"C:\ImagensImport\imagem1000x1000\" };
            if (Directory.Exists(PathDefault))
            {
                string[] arquivos = Directory.GetFiles(PathDefault);
                var nameFile = "";
                var fileResize = "";
                foreach (string arquivo in arquivos)
                {
                    try
                    {
                        nameFile = Path.GetFileName(arquivo);
                        if (nameFile.LastIndexOf(".psd") != -1)
                        {
                            using (MagickImage image = new MagickImage(PathDefault + @"\" + nameFile))
                            {
                                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                                
                                Encoder myEncoder = Encoder.Quality;
                                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder,50L);
                                   fileResize = settings.NameFolder;
                                    Size newSize = new Size(settings.Width, settings.Heigth);
                                    var bmp1 = ResizeImage(image.ToBitmap(), newSize);
                                        myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                   
                                    myEncoderParameters.Param[0] = myEncoderParameter;
                                    bmp1.Save(settings.ImagePath + nameFile + ".Jpg", jgpEncoder,
                                        myEncoderParameters);
                                image.Dispose();
                                myEncoderParameter.Dispose();
                                myEncoderParameters.Dispose();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        using (StreamWriter sw = File.AppendText(strPath))
                        {
                            sw.WriteLine("=============Error File ===========");
                            sw.WriteLine("===========NameFile============= " + nameFile);
                        }
                    }
                }
            }
        }
        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        private static Bitmap ResizeImage(Bitmap mg, Size novoTamanho)
        {
            using (Bitmap i_Bmp = mg)
            {
                double ratio = 0d;
                double myThumbWidth = 0d;
                double myThumbHeight = 0d;
                int x = 0;
                int y = 0;
                Bitmap bp;
                if ((mg.Width / Convert.ToDouble(novoTamanho.Width)) > (mg.Height /
                Convert.ToDouble(novoTamanho.Height)))
                    ratio = Convert.ToDouble(mg.Width) / Convert.ToDouble(novoTamanho.Width);
                else
                    ratio = Convert.ToDouble(mg.Height) / Convert.ToDouble(novoTamanho.Height);
                myThumbHeight = Math.Ceiling(mg.Height / ratio);
                myThumbWidth = Math.Ceiling(mg.Width / ratio);
                //Size thumbSize = new Size((int)myThumbWidth, (int)myThumbHeight);
                Size thumbSize = new Size((int)novoTamanho.Width, (int)novoTamanho.Height);
                bp = new Bitmap(novoTamanho.Width, novoTamanho.Height);
                x = (novoTamanho.Width - thumbSize.Width) / 2;
                y = (novoTamanho.Height - thumbSize.Height);
                Graphics g = Graphics.FromImage(bp);
                g.FillRectangle(Brushes.White, 0, 0, bp.Width, bp.Height);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Rectangle rect = new Rectangle(x, y, thumbSize.Width, thumbSize.Height);
                g.DrawImage(mg, rect, 0, 0, mg.Width, mg.Height, GraphicsUnit.Pixel);
                return bp;
            }
        }
    }
