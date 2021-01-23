    class Sales
    {
        string productname;
        double price;
        private DateTime _salesDate;
        private List<Client> _SoldTheItemTo;
        
        public Sales(string productname, double price)
        {
            this.productname = productname;
            this.price = price;
            _salesDate = DateTime.Now;
            Client C = new Client();
            C.Name = "XYZ";
            _SoldTheItemTo.Add(C);
        }
    }
