     while (!file.EndOfStream)
    	{
    		string line = file.ReadLine();
    		string[] fields = line.Split(",".ToCharArray());
    		
    		Patient p = new Patient();
    
            int id = 0;
            DateTime dob = DateTime.MinValue;
            DateTime visit1 = DateTime.MinValue;
            int duration1 = 0;
            //... etc. for each visit 2, 3, 4 and 5
    		int.TryParse(fields.ElementAtOrDefault(0), out id);
    		p.Name = fields.ElementAtOrDefault(1);
    		p.NIN = fields.ElementAtOrDefault(2);
    		DateTime.TryParse(fields.ElementAtOrDefault(3), out dob);            
    		p.Gender = fields.ElementAtOrDefault(4);
    		DateTime.TryParse(fields.ElementAtOrDefault(5), out visit1);
    		int.TryParse(fields.ElementAtOrDefault(6), out duration1);
            //... etc. for each visit 2, 3, 4 and 5
      
            p.ID = id;
            p.DOB = dob;
            p.Visit1 = visit1;
            p.Duration1 = duration1;
            //... etc. for each visit 2, 3, 4 and 5
    		
    		patientList.Add(p);
    	}
