        private ObservableCollection<Products> _productCollectionView;
        
        public ObservableCollection<Products> ProductCollectionView 
        {
            set { _productCollectionView = value; }
            get
            {
                if (_productCollectionView == null)
                {
                    ReloadProducts();
                }
                return _productCollectionView ;
            }
        }
        
        public void ReloadProducts()
        {
          ProductCollectionView.Clear();
          ObservableCollection<Products> ProductCollectionView = 
    new ObservableCollection<Products>(Entities.Products.ToList());
        }
