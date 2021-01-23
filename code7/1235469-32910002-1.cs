    public class IterApp
        {
           public int CurrentMonth { get; set; }
           public string MonthName { get; set; }
        
        }
        
        public ActionResult NumberApp()
        {
            IterApp model = new IterApp();
            return View();
        }
        
        [HttpPost]
        public ActionResult NumberAppResults(IterApp ia)
        {
            //You might need to move this around to where it's appropriate, 
            //but this will return the name of the month for the int value
            //that you receive. The if/else you have should be unnecessary.
           
            ia.MonthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(ia.CurrentMonth);
            return View(ia);
        }
