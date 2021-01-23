    public ActionResult AddToBasket(int? id)
    {
        if (Session["Basket"] == null)
        {
            Session["Basket"] = new List<int>();
        }
    
        var items = (List<int>)Session["Basket"];
        items.Add(id.Value);
        Session["Basket"] = items;
        ViewBag.List = Session["Basket"];
    
        return RedirectToAction("Index");
    }
