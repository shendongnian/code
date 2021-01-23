            public ViewModel()
        {
            Order = new OrderEntity { Name = "someOrder",OrderNumber="my order", Quantity = 23 };
            Order.PropertyChanged += (o, args) => ((INotifyErrorObject)o).ValidateProperty(args.PropertyName);
        }  
