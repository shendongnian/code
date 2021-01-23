    public class Banner : Resource
    {
        public Banner([Named(pngLoaderName)] IResourceLoader ResourceLoader)
                :base(ResourceLoader)
        { }
    }
    public class MetaData : Resource
    {
        public MetaData ([Named(xmlLoaderName) IResourceLoader ResourceLoader)
                :base(ResourceLoader)
        { }
    }
