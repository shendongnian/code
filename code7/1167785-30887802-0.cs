    class Sales
    {
        string productname;
        double price;
        private DateTime _salesDate;
        public Sales(string productname, double price, Client soldTo)
        {
            this.productname = productname;
            this.price = price;
            this.SoldTo = soldTo;
            _salesDate = DateTime.Now;
        }
        Client SoldTo {get; private set;}
    }
