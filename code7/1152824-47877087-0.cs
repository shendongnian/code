    using (MyEntities db = new MyEntities())                
    {
       db.Configuration.AutoDetectChangesEnabled = false; // <----- trick
       db.Configuration.LazyLoadingEnabled = false; // <----- trick
    
       DateTime Created = DateTime.Now;
    
       var obj = from tbl in db.MyTable
          where DateTime.Compare(tbl.Created, Created) == 0
          select tbl;
    
       dataGrid1.ItemsSource = obj.ToList();
       dataGrid.Items.Refresh();
    }
