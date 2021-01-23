    using (DataClasses1DataContext DataContext = new DataClasses1DataContext())
    {
        int Id = ListOfOrders.First().Id;
        var myListOftblItems = DataContext.tblItems.Where(t => t.IdOrder == Id).ToList();
    }
