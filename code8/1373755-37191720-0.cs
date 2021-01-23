    Button bt = (Button)sender;
           int productId = (int)bt.Tag;
           AddProductDataContext db = new AddProductDataContext();
           decimal Quantity;
           decimal.TryParse(txtCalculator.Text, out Quantity);
         var results  = from inv in db.Inventories
                                              where inv.RecId == productId
                                              select new
                                              {
                                                  inventoryName = inv.InventoryName,
                                                  Quantity,
                                                  Total = Quantity * inv.InventoryPrice
                                              };
        
                   DataTable dt = new DataTable();
                   dt.Columns.Add("inventoryName");
                   dt.Columns.Add("Quantity");
                   dt.Columns.Add("Total");
        
                   foreach (var x in results)
                   {
                       DataRow newRow = dt.Rows.Add();
                       newRow.SetField("inventoryName", x.inventoryName);
                       newRow.SetField("Quantity", x.Quantity);
        
                       newRow.SetField("Total", x.Total);
        
                   }
        
                   gridControl1.DataSource = dt;
                   gridView1.AddNewRow();
