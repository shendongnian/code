    public ActionResult GetItemList()
    {
        var search = Request.Params["term"];
        var itemList = (from items in db.TblItems where items.ItemName.StartsWith(search) select new { label = items.ItemName, value = items.ItemName }).ToList();
        return Json(itemList, JsonRequestBehavior.AllowGet);
    }
