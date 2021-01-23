    public class ScaleHandle
    {
        protected static Texture2D ImageToTexture(Image srcImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(srcImage));
            using(MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(data);
            return tex;
        }
        public Texture2D scaleHandleTexture = ImageToTexture(DaiMangou.Properties.GeneralImageResources.ScaleHandle);
    }
