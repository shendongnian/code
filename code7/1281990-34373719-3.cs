        private IDialogService _dialogService;
        public EditProductViewModel(IDialogService dialogService)
        {
           this._dialogService = dialogService;  
        }
       
        private void SaveProduct(object product)
        {
            SelectedProduct = SelectedProductTemp;
            _dialogService.CloseDialog();
        }
        public void Present(EditProductViewModel prodVM) 
        {
            _dialogService.ShowDialog(prodVM);
        }
       
