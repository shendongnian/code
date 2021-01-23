    //Make a model of you data
    public class L {
    	public int Year {get; set;}
    	public string Months {get; set;}
    	public int NumOfCars {get; set;}
    }
    
    void Main()
    {
    
    	List<L> myList = new List<L>();
    	
       //Load you arrays into the structure
    	myList.Add(new L { Year = 1930, Months = "January", NumOfCars = 10});
    	myList.Add(new L { Year = 2000, Months = "May", NumOfCars = 5});
    	myList.Add(new L { Year = 2030, Months = "December", NumOfCars = 30});
    	
        //Use LINQ
    	var r = myList.Where(x => x.Year == 2000).Select(x => x);
    	
    	Console.Write(r);
    }
