        using (var context = new DataClasses1DataContext())
        {
            data.Configuration.LazyLoadingEnabled = false;
            _orders = context.tblOrder.ToList();
        }
