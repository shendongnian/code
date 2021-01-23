     while (!file.EndOfStream)
    	{
    		string line = file.ReadLine();
    		string[] fields = line.Split(",".ToCharArray());
    		
    		Patient p = new Patient();
    
    		int.TryParse(fields.ElementAtOrDefault(0), out p.ID);
    		p.Name = fields.ElementAtOrDefault(1);
    		p.NIN = fields.ElementAtOrDefault(2);
    		DateTime.TryParse(fields.ElementAtOrDefault(3), out p.DOB);            
    		p.Gender = fields.ElementAtOrDefault(4);
    		DateTime.TryParse(fields.ElementAtOrDefault(5), out p.Visit1);
    		int.TryParse(fields.ElementAtOrDefault(6), out p.Duration1);
    		DateTime.TryParse(fields.ElementAtOrDefault(7), out p.Visit2);
    		int.TryParse(fields.ElementAtOrDefault(8), out p.Duration2);
    		DateTime.TryParse(fields.ElementAtOrDefault(9), out p.Visit3);
    		int.TryParse(fields.ElementAtOrDefault(10), out p.Duration3);
    		DateTime.TryParse(fields.ElementAtOrDefault(11), out p.Visit4);
    		int.TryParse(fields.ElementAtOrDefault(12), out p.Duration4);
    		DateTime.TryParse(fields.ElementAtOrDefault(13), out p.Visit5);
    		int.TryParse(fields.ElementAtOrDefault(14), out p.Duration5);
    		
    		patientList.Add(p);
    	}
