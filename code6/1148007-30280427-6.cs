    public class Statisztika
    {
    	private int iday = 0;
    	private int ipersonid = 0;
    	private int ivisitor =0;
    	private int icount =0;
    	
    	//class constructor
    	public Statisztika(string[] twolines)
    	{
    		iday = Convert.ToInt32(twolines[0].Split(' ')[0]);
    		ipersonid = Convert.ToInt32(twolines[0].Split(' ')[1]);
            //we have to replace these lines:
    		//ivisitor = Convert.ToInt32(twolines[1].Split('/')[0]);
    		//icount = Convert.ToInt32(twolines[1].Split('/')[1].Split(' ')[0]);
            //with:
  		    //check for single slash
		    int pos = twolines[1].IndexOf("/");
		    if (pos>-1)
		    {
                //in case of error TryParse method returns zero
			    Int32.TryParse(twolines[1].Substring(0,pos)
                    .Replace("#", "").Trim(), out ivisitor);
                Int32.TryParse(twolines[1].Substring(pos+1,2)
                    .Replace("#","").Trim(), out icount);
	    	}
    	}
    	
    	public int Day
    	{
    		get {return iday;}
    		set {iday = value;}
    	}
    	
    	public int PersonId
    	{
    		get {return ipersonid;}
    		set {ipersonid = value;}
    	}
    
    	public int Visitor
    	{
    		get {return ivisitor;}
    		set {ivisitor = value;}
    	}
    	
    	public int CountOfVisits
    	{
    		get {return icount;}
    		set {icount = value;}
    	}
    }
