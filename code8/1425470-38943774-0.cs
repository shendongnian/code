    public interface IFrameworkElement
    {
        /* Let's suppose we have just one property, since it is a sample */
        object DataContext
        {
            get;
            set;
        }
    }
    
    public class FrameworkElementImpl : IFrameworkElement
    {
        private readonly dynamic target;
    
        public FrameworkElementImpl(dynamic target)
        {
            this.target = target;
        }
    
        public object DataContext
        {
            get
            {
                return target.DataContext;
            }
            set
            {
                target.DataContext = value;
            }
        }
    }
    
    public static class DependencyObjectExtension
    {
        public static IFrameworkElement AsIFrameworkElement(this DependencyObject dp)
        {
            if (dp is FrameworkElement || dp is FrameworkContentElement)
            {
                return new FrameworkElementImpl(dp);
            }
    
            return null;
        }
    }
