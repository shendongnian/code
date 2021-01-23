    string sFileName = @"D:\veetel.txt";
    string[] alap = File.ReadAllLines(sFileName);
    
    List<Statisztika> stat = new List<Statisztika>();
    for(int i=0; i<alap.Length; i+=2)
    {
    	//Linq rules! 
    	string[] twolines = alap.Skip(i).Take(2).ToArray();
    	//create new Statisztika object and add to list
    	stat.Add(new Statisztika(twolines));
    }
    
    //use create linq query, group data by day and visitor type ;)
    var qry = stat
    	.GroupBy(p=>new{p.Day, p.Visitor})
    	.Select(grp=>new
    			{
    				Day = grp.Key.Day,
    				Visitor = grp.Key.Visitor,
    				SumOfVisits = grp.Sum(p=>p.CountOfVisits)
    			})
		.OrderBy(a=>a.Day)
		.ThenBy(a=>a.Visitor);
    Console.WriteLine("Day Visitor SumOfVisits");
    foreach(var sta in qry)
    {
    	Console.WriteLine("{0}\t{1}\t{2}", sta.Day, sta.Visitor, sta.SumOfVisits);
    }
