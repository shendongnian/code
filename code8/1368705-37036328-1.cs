    public class FirstFeature:Feature
    {
        public FirstFeature(IWebApi webApi):base(webApi){}
        protected override object _execFeature ()
        {
            //your code for first Feature
            //return response if no error else return null
        }
    }
    public class SecondFeature:Feature
    {
        public SecondFeature(IWebApi webApi):base(webApi){}
        protected override object _execFeature ()
        {
            //your code for second Feature
            //return class name[0] if no error else return null
        }
    }
