    public class Data
    {
        private HttpContextBase contextBase;
        public Data(HttpContextBase context)
        {
            this.context = context;
        }
        public Data() : this(new HttpContextWrapper(HttpContext.Current))
        {
        }
    
        public void GetData()
        {
            var user = this.context.User.Identity.Name
        }
    }
