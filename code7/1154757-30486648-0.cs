    string DateString = "";
    var start = DateTime.Now;
    var Dates = GetBusinessDays(start,-7);
    Dates.Reverse();
    foreach (var date in Dates)
    {   
       DateString  = DateString + "'" + date.ToShortDateString() + "',";
     } 
                                    
    DateString = DateString.TrimEnd(',');
    var book = from m in Connection.Db.Materials 
               where m.TypeId == 1 
               group m by m.CreationDate into g select g;
               var results = Dates.Select(d => new { Date = d.Day + "/" + d.Month + "/" + d.Year, Count = book.Where(g => g.Key.Day == d.Day && g.Key.Month == d.Month && g.Key.Year == d.Year).Count() }).ToList(); 
    //put day, month and year. Because only dates  equals with ohter dates.(I need only dates not times)
                                        
    string Books = "";
    foreach(var r in results)
    {
      Books = Books + r.Count + ',';
    }
