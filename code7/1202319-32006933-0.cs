    using (DataClasses1DataContext DataContext = new DataClasses1DataContext())
    {
        int Id = ListOfOrders.First().Id;
        var myListOftblItems = DataContext.tblOrder.Find(Id).tblItems.ToList();
    }
