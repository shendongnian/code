    public class ImageManager
    {
        private static Dictionary<string, Image> _images = new Dictionary<string, Image>();
        private static object _locker = new object();
        public static Image GetImageByTypeKey(string key)
        {
            if (!_images.ContainsKey(key))
            {
                lock (_locker) {
                    if (!_images.ContainsKey(key))
                    {
                        //Add your real loading logic here + handle exceptions (not found, etc...)
                        Image image = Image.FromFile(key + ".png");
                        _images.Add(key,image);
                    }
                }
            }
            return _images[key];
        }
    }
    
    public abstract class BaseType
    {
        public Image Symbol
        {
            get
            {
                return ImageManager.GetImageByTypeKey(SymbolKey);
            }
        }
        protected abstract string SymbolKey { get;  }
    }
    
    public class TypeA : BaseType
    {
        protected override string SymbolKey
        {
            get { return "TypeA";}
        }
    }
