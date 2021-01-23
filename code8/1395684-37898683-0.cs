    private void button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            
    {  
    if (gridSplitPayment.View.IsRowSelected(gridSplitPayment.View.FocusedRowHandle))
                
    {
      decimal a, b;
      int  productId = Convert.ToInt32(gridSplitPayment.GetCellValue(gridSplitPayment.View.FocusedRowHandle, "ProductId").ToString());
    a = Convert.ToDecimal(gridSplitPayment.GetCellValue(gridSplitPayment.View.FocusedRowHandle, "Quantity"));
    b = a - 1;
    
    gridSplitPayment.SetCellValue(gridSplitPayment.View.FocusedRowHandle, "Quantity", b);
    
    
                    BOneRestEntities db = new BOneRestEntities();
                    var results = from inv in db.Inventory
                                  where inv.RecId == productId
                                  select new
                                  {
                                      inventoryName = inv.InventoryName,
                                      Quantity = inv.Quantity,
                                      Total = b * inv.InventoryPrice,
                                      ProductId = inv.RecId
                                  };
    
                    foreach (var x in results)
                    {                    gridSplitPayment.SetCellValue(gridSplitPayment.View.FocusedRowHandle, "Total", x.Total);
                    }
    gridSplitPayment.RefreshRow(gridSplitPayment.View.FocusedRowHandle);
                    gridSplitPayment.RefreshData();
    }
    int proId = Convert.ToInt32(gridSplitPayment.GetCellValue(gridSplitPayment.View.FocusedRowHandle, "ProductId").ToString());
    decimal qty = Convert.ToDecimal(gridSplittedPaymentRight.GetCellValue(gridSplittedPaymentRight.View.FocusedRowHandle, "Quantity"));
                BOneRestEntities dbe = new BOneRestEntities();
    
                var result = from inv in dbe.Inventory
                             where inv.RecId == proId
                             select new
                             {
                                 ProductId = inv.RecId,
                                 inventoryName = inv.InventoryName,
                                 Quantity = qty,
                                 Total =  inv.InventoryPrice
                             };
    
    
                foreach (var y in result)
                {
                    if (qty == 0)
                    {
                        DataRow row = dt1.NewRow();
                    row.SetField("inventoryName", y.inventoryName);
                        row.SetField("Quantity", y.Quantity + 1);
                        row.SetField("Total", y.Total);
                    row.SetField("ProductId", y.ProductId);
                
                        dt1.Rows.Add(row);
                    }
    
    
                    else
                    {
                        gridSplittedPaymentRight.SetCellValue(viewSplittedPayment.FocusedRowHandle, "Quantity", qty + 1);
                        gridSplittedPaymentRight.SetCellValue(viewSplittedPayment.FocusedRowHandle, "Total", qty*y.Total);
                    }
                   
                }
    
                gridSplittedPaymentRight.ItemsSource = dt1;
    
                }
   
