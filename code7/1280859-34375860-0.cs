        public CustomerOrdersViewModel(IDataService<OrderModel> orderDataService, IDialogService dialogservice)
        {                  
            this._orderDataService = orderDataService;
            this._dialogService = dialogservice;
            Messenger.Default.Register<CustomerModel>(this, OnUpdateOrderMessageReceived);
            LoadCommands();     
        }
        private void OnUpdateOrderMessageReceived(CustomerModel customer)
        {
            SelectedCustomerEmail = customer.Email;
            IsEnabled = true;                
        }
        private async Task WindowLoadedAsync(object obj)
        {
            await LoadCustomerOrdersAsync(SelectedCustomerEmail);
        }
