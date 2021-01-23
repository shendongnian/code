    public class GetResource
    {
        public Image GetImageFromResource(string resourceFolder, string resourceName, string extension)
        {
            return Image.FromStream(this.GetStreamFromResource(resourceFolder, resourceName, extension), true);
        }
        private Stream GetStreamFromResource(string ResourceFolder, string resourceName, string Extension)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            return myAssembly.GetManifestResourceStream(myAssembly.GetName().Name + "." + ResourceFolder + "." + resourceName + "." + Extension);
        }
    }
