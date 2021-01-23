    [HttpPost]
    public ActionResult AddtopoOrderList(string Qty, string ProductName, string Description, string Price, string Amount)
    {
        POdb.poOrderList.Add(new PO_OrderList 
        { 
            Qty = Convert.ToInt32(Qty),
            ProductName = ProductName,
            Description = Description,
            UnitPrice = Convert.ToInt16(UnitPrice),
            Amount = Convert.ToInt16(Amount)
        });
        POdb.SaveChanges();
        return RedirectToAction("Index");
    }
