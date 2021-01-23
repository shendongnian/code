    public class AuthorizeAttribute : ActionFilterAttibute
    {
        private readonly string _attribute;
        public AuthorizeAttribute(string attribute)
        {
            _attribute = attribute;
        }
    }
