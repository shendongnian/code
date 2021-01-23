    void Main()
    {
      ExcelPackage pck = new ExcelPackage();
    
      var collection1 = from c in db.Customers
                        select new
                        {
                          CustomerName = c.CompanyName,
                          ContactPerson = c.ContactName,
                          FirstOrder = c.Orders.Min(o => o.OrderDate),
                          LastOrder = c.Orders.Max(o => o.OrderDate),
                          OrderTotal = c.Orders.Any() ? c.Orders.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice)) : 0M,
                          Orders = c.Orders.Count()
                        };
      var collection2 = db.Orders.Select(o => new {
             OrderId = o.OrderID, Customer=o.CustomerID, OrderDate=o.OrderDate});
    
      var ws1 = pck.Workbook.Worksheets.Add("My Sheet 1");
    
      //Load the collection1 starting from cell A1 in ws1
      ws1.Cells["A1"].LoadFromCollection(collection1, true, TableStyles.Medium9);
      ws1.Cells[2, 3, collection1.Count() + 1, 3].Style.Numberformat.Format = "MMM dd, yyyy";
      ws1.Cells[2, 4, collection1.Count() + 1, 4].Style.Numberformat.Format = "MMM dd, yyyy";
      ws1.Cells[2, 5, collection1.Count() + 1, 5].Style.Numberformat.Format = "$#,##0.0000";
      ws1.Cells[ws1.Dimension.Address].AutoFitColumns();
    
      var ws2 = pck.Workbook.Worksheets.Add("My Sheet 2");
    
      //Load the collection1 starting from cell A1 in ws1
      ws2.Cells["A1"].LoadFromCollection(collection2, true, TableStyles.Medium9);
    
      //...and save
      var fi = new FileInfo(@"d:\temp\AnonymousCollection.xlsx");
      if (fi.Exists)
      {
        fi.Delete();
      }
      pck.SaveAs(fi);
    }
