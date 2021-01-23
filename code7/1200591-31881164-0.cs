        void DirSearch(string MYPHRASE) 
    {
    	try	
    	{
    	   foreach (string d in Directory.GetDirectories(MYPHRASE)) 
    	   {
    		foreach (string f in Directory.GetFiles(d, txtFile.Text)) 
    		{
    		   lstFilesFound.Items.Add(f);
    		}
    		DirSearch(d);
    	   }
    	}
    	catch (System.Exception excpt) 
    	{
    		Console.WriteLine(excpt.Message);
    	}
    }
