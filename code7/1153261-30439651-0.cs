    public class Data
    {
        private HttpContextBase contextBase;
        public Data(HttpContextBase context)
        {
            this.context = context;
        }
        public Data() : this(HttpContext.Current)
        {
        }
    
        public void GetData()
        {
            var user = this.contextBase
        }
    }
