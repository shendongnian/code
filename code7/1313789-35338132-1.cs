    public ActionResult Filter(int number1, int number2)
    {    
        var model = new MyViewModel
        {
           Number1 = number1,
           Number2 = number2,
           GiftList = db.Gifts.Where(c => c.Price > number1 && c.Price <= number2).ToList()
        }      
    
         return View(model);
    }
