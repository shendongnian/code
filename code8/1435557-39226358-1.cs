        public CustomerViewModel()
        {
            IList<Customer> customers = Customer.GetCustomers().ToList();
            _customerView = CollectionViewSource.GetDefaultView(customers);
            _customerView.MoveCurrentToLast();
            _customerView.CurrentChanged += CustomerSelectionChanged;
        }
        private void CustomerSelectionChanged(object sender, EventArgs e)
        {
            // React to the changed selection
            Debug.WriteLine("Here");
            var sel = (sender as CollectionView).CurrentItem;
            if ( sel!= null)
            {
                //Do Something          
            }
        }
        private DelegateCommand loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new DelegateCommand(VMLoad);
                }
                return (ICommand)loadCommand;
            }
        }
        bool IsLoaded = false;
        private void VMLoad(object obj)
        {
            IsLoaded = true;
        }
