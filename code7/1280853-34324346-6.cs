       public CustomerOrdersViewModel(IDataService<OrderModel> orderDataService)
        {
             _customerOrders =  new List<OrderModel>();// initialised. So it wont be null at the beginning.
            this._orderDataService = orderDataService;         
            this.Initialization = InitializeAsync(); // the async method should fire "PropertyChanged" after populating the collection.
        }
