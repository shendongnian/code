    public class EmbeddedResources
    {
        public static Assembly self { get { return Assembly.GetExecutingAssembly(); } }
    
        public static Bitmap image(string name)
        {
            Bitmap result = null;
    
            // note: typeof(EmbeddedResources).Namespace will only work if EmbeddedResources is defined in the default namespace
            using (Stream res = self.GetManifestResourceStream(typeof(EmbeddedResources).Namespace + "." + name))
            {
    
                using (Image tmp = Image.FromStream(res))
                {
                    result = new Bitmap(tmp.Width, tmp.Height, tmp.PixelFormat);
                    result.SetResolution(tmp.HorizontalResolution, tmp.VerticalResolution);
                    using (Graphics g = Graphics.FromImage(result))
                    {
                        g.DrawImage(tmp, Point.Empty);
                    }
                }
            }
            return result;
        }
    
    }
