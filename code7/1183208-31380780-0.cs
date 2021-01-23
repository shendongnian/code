    public ActionResult UpdateProductCount(int? productID, int? count)
        {
            if (productID.HasValue)
            {
    Transaction t = new Transaction();
        t.Count += count.Value;
        t.Total= t.Count * t.Price;
                
                if (transaction == null)
                    return Json(t, JsonRequestBehavior.AllowGet);           
        }
