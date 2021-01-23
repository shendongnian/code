    void Main()
    {
      string path   = @"D:\data\Northwind.accdb";
      string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path;
        
      var provider= new AccessQueryProvider(new OleDbConnection(conStr), 
                        new ImplicitMapping(), QueryPolicy.Default);
      
      var sampleOrders = provider.GetTable<Order>("Orders")
                      .Where (o => o.OrderDate == new DateTime(1997,1,1));
      
      Form f = new Form{Height=800,Width=1024};
      DataGridView dgv = new DataGridView { Dock=DockStyle.Fill };
      dgv.DataSource = sampleOrders.ToList();
      
      f.Controls.Add(dgv);
      f.Show();
    }
    
    // Entity Class
    public class Order {
     public int OrderID { get; set; }
     public string CustomerID { get; set; }
     public int EmployeeID { get; set; }
     public DateTime OrderDate { get; set; }
     public DateTime? RequiredDate { get; set; }
     public DateTime? ShippedDate { get; set; }
     public int ShipVia { get; set; }
     public decimal? Freight { get; set; }
     public string ShipCity { get; set; }
     public string ShipCountry { get; set; }
    }
  
