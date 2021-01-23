    public static class FontHelper
    {
        public static byte[] ArialUnicodeMS
        {
            //the font is in the folder "/fonts" in the project
            get { return LoadFontData("MyApp.fonts.ARIALUNI.TTF"); }
        }
        /// Returns the specified font from an embedded resource.
        static byte[] LoadFontData(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                    throw new ArgumentException("No resource with name " + name);
                int count = (int)stream.Length;
                byte[] data = new byte[count];
                stream.Read(data, 0, count);
                return data;
            }
        }
    }
