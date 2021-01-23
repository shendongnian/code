    public class MyModel 
    {
    	public Int32 N1 {get;set;}
    	public Int32 N2 {get;set;}
    }
    public ActionResult Filter(int number1, int number2)
    {          
    	var result = db.Gifts.Where(c => c.Price > number1 && c.Price <= number2).ToList();    	
    	return View(new MyModel{N1 = 50, N2 = 100});
    }
