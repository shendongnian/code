    public class Masina
    {
        public ImageSource MasinaPav { get; private set; }
        ...
        public Masina()
        {
            using (var fileStream = new FileStream(
                "teksturos/masinos/red/top.png",
                FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.DecodePixelWidth = 100;
                bitmap.DecodePixelHeight = 200;
                bitmap.StreamSource = fileStream;
                bitmap.EndInit();
                bitmap.Freeze();
                MasinaPav = bitmap;
            }
        }
    }
