    public class Person
    {       
        public int id { get; set; }
     
        private List<Order> _orders;
  
        public List<Order> orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new List<Order>();
                }
                return _orders;
            }
            set { _orders = value; }
        }
    }
