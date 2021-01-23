        private void QueryDataFromPersistence()
        {
            List<CustomerModel> listc = _customerDataService.GetAllCustomers();
            Customers = new ObservableCollection(listc);
        }
