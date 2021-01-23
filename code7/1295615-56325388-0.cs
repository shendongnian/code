    internal class databaseItemModel
    {
        int _id; 
        string _description;
        decimal _price; 
        decimal _quantity;
        decimal _cost;
        bool _modified;
        public databaseItemModel()
        {
            _modified = false;
        }
        public int id { get { return _id; } }
        public bool modified { get { return _modified; } }
        public string description { get { return _description; } set { _description = value; _modified = true; } }
        public decimal price { get { return _price; } set { _price = value; _modified = true; } }
        public decimal quantity { get { return _quantity; } set { _quantity = value; _modified = true; } }
        public decimal cost { get { return _cost; } set { _cost = value; _modified = true; } }
        public bool selected { get; set; }
        public void setId(int _idvalue) 
        {
            _id = _idvalue;
        }
        public decimal value
        {
            get { return price * quantity; }
        }
        public void setDescription(string _descr)
        {
            _description = _descr; 
        }
        public void setPrice(decimal _pr)
        {
            _price = _pr;
        }
        public void setQuantity(decimal _qty)
        {
            _quantity = _qty;
        }
        public void setCost(decimal _cst) 
        {
            _cost = _cst;
        }
    }
