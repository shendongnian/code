    public class Product
    {
        private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    
        private float _price = 0.0;
        public float Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
    
        public Product(string name, float price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
