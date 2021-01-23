	 	List<EnteteCommande> Ent = new List<EnteteCommande>();
		var E1 = new EnteteCommande { code = "011" , Date = "10/05/2016" , Ref = "01236" };
		var E2 = new EnteteCommande { code = "012" , Date = "10105/2016" , Ref = "01237" };
		Ent.Add(E1); 
		Ent.Add(E2); 
		List<string> Status = new List<string>{ "test1" , "test2"};
		
		var result = Ent.Zip(Status, (e,s) => new {e.code, e.Date, e.Ref, status = s}).ToList(); 
