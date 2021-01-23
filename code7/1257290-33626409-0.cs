    public class ExtendedMap : Map : IList
    {
        public ExtendedMap()
        {
    
        }
    
        private IList<Pin> _staticPins = new List<Pin>();
        public IList<Pin> StaticPins
        {
            get { return _staticPins; }
            set { _staticPins = value;}
        }
    
        //..IList Implementations
    
        Public int Add(object item)
        {
           var pin = (Pin)item;
           StaticPins.Add(pin);
           return 1;
        }
    }
