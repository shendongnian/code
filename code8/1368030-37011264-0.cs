    public class A
    {
        private int _ever;
        private List<A> _list = new List<A>();
        
        public int Ever
        {
            get { return _ever; }
            set
            { 
                _ever = value;
                foreach (A a in _list)
                {
                    a.Ever = value;
                }
            }
        }
    }
