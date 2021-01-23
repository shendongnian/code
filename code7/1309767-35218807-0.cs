    public class ComparableImage
    {
        public Image Image
        {
            get { return this.image; }
            set { SetImage(value); }
        }
        public string SHA1
        {
            get { return this.sha1; }
        }
        private Image image = null;
        private string sha1 = string.Empty;
        // This is the important part that lets us 
        // efficiently compare two images:
        public override bool Equals(object image)
        {
            if ((image != null) && (image is ComparableImage) )
            {
                return (sha1.Equals(((ComparableImage)image).sha1));
            }
            else return false;
        }
        public override int GetHashCode()
        {
            return sha1.GetHashCode();
        }
        private void SetImage(Image image)
        {
            this.image = image;
            this.sha1 = ComputeSHA1(image);
        }
        private static string ComputeSHA1(Image image)
        {
            if (image != null)
            {
                var bytes = GetBytes(image);
                using (SHA1Managed SHA1 = new SHA1Managed())
                {
                    return Convert.ToBase64String(SHA1.ComputeHash(bytes));
                }
            }
            else return string.Empty;
        }
        private static byte[] GetBytes(Image image)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Bmp);
                return stream.ToArray();
            }
        }
    }
