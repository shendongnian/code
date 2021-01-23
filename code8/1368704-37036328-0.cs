    public abstract class Feature:IFeature
    {
        public static readonly string Error = "Error accessing api...";
        public static readonly string Hello = "Hello ...{0}";
        protected IWebApi webApi;
        protected Feature(IWebApi webApi)
        {
            this.webApi = webApi;
        }
        public async Task execFeature()
        {
            var o = _execFeature();
            IResult result;
            if(o==null)
                result = new TextResult(Error);
            else 
                result = new TextResult( string.Format(Hello, o);
            result.display();
        }
        protected abstract object _execFeature();
    }
