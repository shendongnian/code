    public class Observation
    {
  	    public int Systolic { get; set; }
	    public DateTime ObsTime { get; set;}
    }
    
    public List<Observation> RandomBPSValue()
    {
        List<Observation> myList = new List<Observation>();
	
	    Random random = new Random();
        int RandomNumber = random.Next(90, 120);
        for (int runs = 1; runs < 41; runs = runs + 5)
        {
            Observation observation = new Observation() { ObsTime = DateTime.Now, Systolic = runs};
		    myList.Add(observation);
        }
	    return myList;
    }
