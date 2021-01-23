    class BusinessLayer
    {
        private DataLayer _dataLayer;
        public BusinessLayer()
        {
            _dataLayer = new DataLayer();
        }
        internal List<string> GetCategories()
        {
            return _dataLayer.RetrieveCatagories();
        }
    }
