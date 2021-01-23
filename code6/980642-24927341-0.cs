	//keep filename in a constant/variable for easy reuse (better, put it in a config file)
	const string SourceFile = "darColItems.txt";
	//what character separates data elements (if the elements may contain this character you may instead want to look into a regex; for now we'll keep it simple though, & assume that's not the case
    const char delimeter = ',';
	//here's where we'll store our values
	var values = new List<string>();
	//check that our input file exists
	if (File.Exists(SourceFile))
	{
		//using statement ensures file is closed & disposed, even if there's an error mid-process
		using (var reader = File.OpenText(SourceFile))
		{
			string line;
			//read each line until the end of file (at which point the line read will be null)
			while ((line = reader.ReadLine()) != null)
			{
                //split the string by the delimiter (',') and feed those values into our list
				foreach (string value in line.Split(delimiter)
				{
					values.Add(value);
				}
			}
		}
	}
