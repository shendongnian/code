    public class hours
    {
    	public DateTime Start { get; set; }
    	public DateTime End { get; set; }
    }
...
    List<hours> allHrs = new List<hours>{
    	new hours{Start = DateTime.Now.AddHours(-3.2), End = DateTime.Now.AddHours(-2)},
    	new hours{Start = DateTime.Now.AddHours(-3.9), End = DateTime.Now.AddHours(-2.03)},
    	new hours{Start = DateTime.Now.AddHours(-3.8), End = DateTime.Now.AddHours(-2.9)}
    };
    
    //Project a new collection with the math done for number of minutes in each row
    var mins = from h in allHrs
    	select new {nbrMinutes = (h.End - h.Start).Minutes};
    
    //Sum all rows, divide by 60 to get hours
    Double total = mins.Sum (s => s.nbrMinutes / 60.0 );
    
    Console.WriteLine(total);
