    class DialogService : IDialogService
    {
        Window productView = null;
        ProductView _productView;
    
        public DialogService()
        {
             _productView = new ProductView();
        }
        public void ShowDetailDialog()
        {
            _productView.ShowDialog();
        }
    }
