        bool keep;
        List<string> list = new List<string>();
        using (System.IO.StreamReader inputFile = new System.IO.StreamReader(fileName))
        {
             string line;
	         while ((line = inputFile.ReadLine()) != null)
	         {
                  //detemine if keep is true 
                  //also do anything else you need to with the data from the file here
                  if (keep) list.Add(line); 
	         }
        }
        using (StreamWriter outputFile = new StreamWriter(fileName, false))
        {
             foreach(string line in list)
             {
                  outputFile.WriteLine(line)
             }
        }
