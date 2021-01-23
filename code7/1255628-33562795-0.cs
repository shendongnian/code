        private string _total;
        public string Total
        {
            get
            {
                _total = Convert.ToString(Collection.Sum(t => t.totalPrice));
                return _total;
            }            
        }
