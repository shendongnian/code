	    List<GroupTemp> list = new List<GroupTemp>();
	    list.Add(new GroupTemp("group1", "1"));
	    list.Add(new GroupTemp("group1", "2"));
	    list.Add(new GroupTemp("group2", "3"));
	    list.Add(new GroupTemp("group2", "4"));
	    list.Add(new GroupTemp("group3", "5"));
	    var groupedList = list.GroupBy(t => t.key).ToList();
	    foreach (var entity in groupedList)
	    {
		    Console.WriteLine(String.Format("Group {0} has {1} elements", entity.Key, entity.Count()));
	    }
   
