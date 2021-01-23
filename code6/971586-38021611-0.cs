    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace export
    {
        class Program
        {
            static void Main(string[] args)
            {
    	foreach (string file in Directory.EnumerateFiles(@"C:\Temp\Images"))
                {
                    	FileInfo file_info = new FileInfo(file);
                    
                            var filePathOriginal = Path.Combine(@"C:\Temp\Images",
                                String.Format("{0}", file_info.Name));
                            if (File.Exists(filePathOriginal) && file_info.Name.Contains(".png"))
                            {
                                Task.Factory.StartNew(() => VaryQualityLevel(filePathOriginal));  
                                Console.WriteLine("Compressed {0}. {1}", count, file_info.Name);
                                count++;
                            }
                }            
                Console.WriteLine("End Compressing {0} Images{2}{2}Date: {1}{2}", count, DateTime.Now, Environment.NewLine);
                Console.WriteLine("Done");
                Console.ReadLine();
            }
    	static void VaryQualityLevel(string file)
            {
                var img = new Bitmap(file);
                try
                {
                    SaveJpeg(img, file); 
                    img.Dispose();
                    if (File.Exists(file))
                        File.Delete(file);
                    File.Move(file + 1, file);
                }
                catch (Exception ex)
                {
                    // Keep going
                }
            }
            static void SaveJpeg(Image img, string filename)
            {
                EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 100L);
                ImageCodecInfo jpegCodec = GetEncoder(ImageFormat.Jpeg);
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;
                img.Save(filename + 1, jpegCodec, encoderParams);
            }
            static ImageCodecInfo GetEncoder(ImageFormat format)
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
    }
