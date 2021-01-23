        public ActionResult ProductsList()
        {
            Random rnd = new Random();
            List<Product> products = productRepo.GetProduct().ToList();
            int randomNo = rnd.Next(1, products.Count); 
            return PartialView(products.Take(randomNo).ToList());
        }
