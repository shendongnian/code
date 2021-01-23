    public static class BespokeFileSorterFactory
    {
        private static HashSet<string> supportedGraphicExtensions = new HashSet<string>
        {
            "jpeg", "png" // Raster, vector, 3D, etc. graphics
        };
        private static HashSet<string> supportedArchiveExtensions = new HashSet<string>
        {
            "ison", "nrg" // and others
        };
        public static BespokeFileSorter Create(string fileExtension)
        {
            if (supportedGraphicExtensions.Contains(fileExtension))
                return new Graphics();
            if (supportedArchiveExtensions.Contains(fileExtension))
                return new Archive();
            throw new NotSupportedException("Unknown file extension");
        }
    }
