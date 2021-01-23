    List<Item> items;
    using(MyDBContext db = new MyDBContext())
    {
        items = db.Items.ToList();
    }
    return View(items);
