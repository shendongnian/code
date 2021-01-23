    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Order = new Order();
            Hold = new Hold();
        }
        public Order Order { get; set; }
        public Hold Hold { get; set; }
    }
    
    public ActionResult Edit(int id)
    {
        
        var o = from o context.Order.Include("Holds").Single(id);
        var model = new OrderViewModel()
        {
            Order = o
        }
        if (o.Holds.Count() > 0)
            model.Hold = o.Holds.Last();
        return View(model);
    }
