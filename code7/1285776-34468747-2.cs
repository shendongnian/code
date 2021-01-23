        public class retViewModel
    {
        public List<int> key { get; set; }
        public List<int> code { get; set; }
    }
  
    public retViewModel func()
            {
                List<int> key = new List<int>() { 2,34,5};
                List<int> code = new List<int>() { 345,67,7};
                retViewModel obj = new retViewModel() { 
                code=code,
                key=key
                };
                return obj;
            }
