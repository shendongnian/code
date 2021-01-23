    public JsonResult TotalIncomeJson()
            {
               var tempD = db.CheckOut.Where(x => x.ISOrderComplete).ToList();
               var data = tempD.GroupBy(x => x.Order.OrderDate.Date).Select(y => new { OrderDate = y.Key, TotalPrice = y.Sum(a => a.TotalPrice) })
                .OrderBy(b=>b.OrderDate.Year).ToList();
               return Json(data, JsonRequestBehavior.AllowGet);
             }
