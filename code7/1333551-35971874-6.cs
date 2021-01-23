    // simple class to associate the signature with the name
    public class ImgHeader
    {
        public readonly string Name;
        public readonly byte[] Header;
        public static readonly ImgHeader GIF89a = new ImgHeader("GIF89a", new byte[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 });
        public static readonly ImgHeader GIF87a = new ImgHeader("GIF87a", new byte[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 });
        public static readonly ImgHeader JPG = new ImgHeader("JPG", new byte[]{0xFF, 0xD8});
        public static readonly ImgHeader PNG = new ImgHeader("PNG", new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A });
        private ImgHeader(string n, byte[] h)
        {
            this.Name = n;
            this.Header = h;
        }
    }
