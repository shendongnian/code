    System.Globalization.CultureInfo provider = new System.Globalization.CultureInfo("tr-TR");
			DateTime Fromtimei=DateTime.ParseExact("130000","HHmmss",provider);
			DateTime Totimei=DateTime.ParseExact("130000","HHmmss",provider);
			
			DateTime Fromtimeii=DateTime.ParseExact("130000","HHmmss",provider);
			DateTime Totimeii=DateTime.ParseExact("120000","HHmmss",provider);
			
			DateTime Fromtimeiii=DateTime.ParseExact("010000","HHmmss",provider);
			DateTime Totimeiii=DateTime.ParseExact("000000","HHmmss",provider);
			
			
			Console.WriteLine(DateTime.Compare(Fromtimeiii,Totimeiii));
			if(DateTime.Compare(Fromtimei,Totimei)==0)
			{
				Console.WriteLine(Fromtimei.ToString()+"\n"+Totimei.ToString() +"\nNot possible - Same for AM\n\n");
			}
			if(DateTime.Compare(Fromtimeii,Totimeii)==1)
			{
				Console.WriteLine(Fromtimeii.ToString()+"\n"+Totimeii.ToString() +"\nNot possible\n\n");
			}
			if(DateTime.Compare(Fromtimeiii,Totimeiii)==1)
			{
				Console.WriteLine(Fromtimeiii.ToString()+"\n"+Totimeiii.ToString() +"\nNot possible\n\n");
			}
