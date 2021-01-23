    class Program
    {
        static void Main(string[] args) {
            List<String> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
            String rootDir = "C:\\Images";
            foreach (String fileName in Directory.EnumerateFiles(rootDir)) {
                if (ImageExtensions.Contains(Path.GetExtension(fileName).ToUpper())) {
                    try {
                        //Image.FromFile will work just as well here.
                        using (Image i = Bitmap.FromFile(fileName)) {
                            if (i.PixelFormat == PixelFormat.Format16bppGrayScale) {
                                //Grey scale...
                            } else if (i.PixelFormat == PixelFormat.Format1bppIndexed) {
                                //1bit colour (possibly b/w, but could be other indexed colours)
                            }
                        }
                    } catch (Exception e) {
                        Console.WriteLine("Error - " + e.Message);
                    }
                }
            }
        }
    }
