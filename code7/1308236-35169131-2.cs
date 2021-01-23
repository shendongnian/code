    class MasterViewModel 
    {
        public ProdutoViewModel ProdutoViewModel { get; set; }
        public EncomendaProdutoViewModel EncomendaProdutoViewModel { get; set; }
        Producto _ProdutoViewModel;
        public Producto ProdutoViewModel 
        { 
            get { return _ProdutoViewModel; } 
            set { 
                    _ProdutoViewModel = value;
                    EncomendaProdutoViewModel.EncomendaProdutos.Add(value); 
                } 
        }
    }
