    var p=new Profile();
    using (StreamReader sr = new StreamReader(filename))
    {
    	while (!sr.EndOfStream)
    	{
    		String line = sr.ReadLine();
    		if (line != null && line.Contains("Student"))
    		{
    			p.studentName=GetLineValue(sr.ReadLine());
    			p.studentLastName=GetLineValue(sr.ReadLine());
    			p.studentUsername=GetLineValue(sr.ReadLine());
    			p.studentPassword=GetLineValue(sr.ReadLine());
    		}
    	
    		if (line != null && line.Contains("Teacher"))
    		{
    			p.teacherName=GetLineValue(sr.ReadLine());
    			p.teacherLastName=GetLineValue(sr.ReadLine());
    			p.teacherUsername=GetLineValue(sr.ReadLine());
    			p.teacherPassword=GetLineValue(sr.ReadLine());
    		}
    	}
    }
    private string GetLineValue(string line)
    {
	   return line.Substring(line.IndexOf('=')+1);
    }
