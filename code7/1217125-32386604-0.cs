    public class ImageManager
    {
        public static Image GetImageByTypeKey(String key)
        {
            //Load,cache and return in here
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
