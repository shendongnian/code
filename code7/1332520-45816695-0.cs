    public static class IWebElementExtensions
    {
        public static IWebElement Unwrap(this IWebElement element)
        {
            return ((IWrapsElement)element).WrappedElement;
        }
    }
