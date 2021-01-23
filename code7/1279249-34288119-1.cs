    private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult ShowBasket()
        {
            List<int> mylist = new List<int>((List<int>)Session["Basket"]);
            List<Product> IntheCart = new List<Product>();
            foreach (var item in mylist)
            {
                IntheCart.Add(db.Productos.Find(item));
            }
           return View(IntheCart);
          }
