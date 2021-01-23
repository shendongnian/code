    public static void GetData()
    {
    	var mainDic = new Dictionary<int, Dictionary<int, List<string>>>();
    	List<Activities> acts = new List<Activities>(); // Your database context.
    
    	acts.Select(x => x.Date.Year).Distinct().ToList().ForEach(
    		year => 
    		{
    			var yearlyDic = new Dictionary<int, List<string>>();
    			acts.Where(x => x.Date.Year == year).Select(x => x.Date.Month).Distinct().ToList().ForEach(
    				month => 
    				{
    					var projects = acts.Where(x => x.Date.Year == year && x.Date.Month == month)
    					.Select(x => x.Project.ProjectNumber).ToList();
    
    					yearlyDic.Add(month, projects);
    				});
    
    			mainDic.Add(year, yearlyDic);
    		});
    }
    
    
