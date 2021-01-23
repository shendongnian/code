    string sFileName = @"D:\veetel.txt";
    string[] alap = File.ReadAllLines(sFileName);
    
    List<Statisztika> stat = new List<Statisztika>();
    for(int i=0; i<alap.Length; i+=2)
    {
    	string[] twolines = alap.Skip(i).Take(2).ToArray();
    	stat.Add(new Statisztika(twolines));
    }
    
    var qry = stat
    	.GroupBy(p=>new{p.Day, p.Visitor})
    	.Select(grp=>new
    			{
    				Day = grp.Key.Day,
    				Visitor = grp.Key.Visitor,
    				SumOfVisits = grp.Sum(p=>p.CountOfVisits)
    			});
    Console.WriteLine("Day Visitor SumOfVisits");
    foreach(var sta in qry)
    {
    	Console.WriteLine("{0}     {1}        {2}", sta.Day, sta.Visitor, sta.SumOfVisits);
    }
