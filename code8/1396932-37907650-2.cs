    public class SomeClass : ISpecificWidget
    {
        void IBaseWidget.Configure(IBaseConfiguration configuration)
        {
            throw new NotImplementedException();
        }
        public void Configure(IChildSpecificConfiguration configuration)
        {
            //do stuff
        }
    }
