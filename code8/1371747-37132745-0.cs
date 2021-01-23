    string [] lines = {"1","2","3"};
		string [] linesTwo = {"2.1","2.2","2.3"};
		var CombinedString = new string[lines.Length + linesTwo.Length];
		
		Array.Sort<string>(CombinedString );
		
		
		
		if(CheckBox1.Checked)
            {
               lines.CopyTo(CombinedString , 0);
	        	linesTwo.CopyTo(CombinedString , lines.Length);
				Array.Sort<string>(CombinedString );
            }
		
