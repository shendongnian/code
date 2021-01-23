    public ActionResult Details(String name, String venue, String date)
    {
        DateTime dt;
    
        if (DateTime.TryParse(date, out dt))
        {
            return View(_repository.performanceDetails(name, venue, dt));    
        }
        else
        {
            return View("Error", "The value passed in date isn't a date value.");
        }
    }
    public PerformanceDetails performanceDetails(String name, String venue, DateTime dt)
    {
        var PerformanceDetails = (from s in _db.PerformanceDetails
                                  where s.show == name && 
                                        s.venue == venue && 
                                       s.performanceDate == dt.Date                  
                                  select s).First();
        return PerformanceDetails;
    
    }
    <%= Html.ActionLink("View Details", "Details", "Performances", 
                    new { name = item.show , 
                          venue = item.venue, 
                          date = item.performanceDate.ToString("dd-MMM-yyyy") }, 
                    new {@class = "button"}) %>
