    // Let's say I have a Customers table and want to search against its Email column
    // First I get my data layer class that inherits from DbContext class
    yourContextClass db = new yourContextClass();
    // below I am getting valueToCheck from a view with GET method
    public ActionResult Index(string valueToCheck)
    {
     bool isExists = false;
     IEnumerable<Customers> customersList = (from cus in db.Customers select cus).ToList();
     int index = customersList.FindIndex(c => c.Email == valueToCheck);
     if (index >= 0) 
      isExists = True;
     // if index is -1 then the value to check does not exist
    return View();
    }
