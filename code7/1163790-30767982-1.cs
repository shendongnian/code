    public abstract class WebBroker
    {
        private IPageProvider _pageProvider;
    
        protected WebBroker(IPageProvider pageProvider)
        {
            _pageProvider = pageProvider;
        }
        public override void CommonThing(int someData)
        {
           var result = _pageProvider.CommonMethod(someData);
           //do something with result
        }
    }
