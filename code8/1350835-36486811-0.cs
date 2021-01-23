	   var obj4 = new { name = "person", date = DateTime.Now.AddDays(1), data = "pr-214-2-20151224-word2-word3" };
	   var listak = new[] { obj4 }.ToList();
	   var u = listak.OrderByDescending(s => s.date).TakeWhile(s => s.date > DateTime.Now).Select(s => new
	   {
	        name = s.name,
	        date = s.date,
	        data = s.data.Split(new[] { "-" }, StringSplitOptions.None).Where(c => c.StartsWith("word")).Select(m => m.Remove(0, 4))
	    });
				
		Console.Write(u);
    				
    				
