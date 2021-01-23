    public abstract class VerbRouteAttribute : RouteFactoryAttribute, IActionHttpMethodProvider
    {
        private string _template;
        private HttpMethod _method;
        public VerbRouteAttribute(string template, string verb)
            : base(template)
        {
            _method = new HttpMethod(verb);
        }
        public Collection<HttpMethod> HttpMethods
        {
            get
            {
                var methods = new Collection<HttpMethod>();
                methods.Add(_method);
                return methods;
            }
        }
        public override IDictionary<string, object> Constraints
        {
            get
            {
                var constraints = new HttpRouteValueDictionary();
                constraints.Add("verb", new VerbConstraint(_method));
                return constraints;
            }
        }
    }
