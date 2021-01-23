        private IDialogService _dialogService;
        public CustomerOrdersViewModel(IDialogService dialogservice)
        {
            this._dialogService = dialogservice;                
        }
               
        private void EditOrder(object obj)
        {
            EditProductViewModel pvm = new EditProductViewModel(_dialogService);
            pvm.Present(pvm);
            Messenger.Default.Send<ProductModel>(SelectedProduct);                              
        }
