    //using System.Data.Entity;
    db.Configuration.ProxyCreationEnabled = false;
    db.Products.Load(); // or db.Products.ToList();
    this.productBindingSource.DataSource = db.Products.Local.ToBindingList();
 
