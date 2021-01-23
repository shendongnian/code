    List<string[]> ConvertToListOfArrays(List<string> list)
    {
    	List<string[]> listOfArrays = new List<string[]>();
    	foreach(string item in list)
    	{
    		listOfArrays.Add(new string[] { item } );
    	}
        return listOfArrays ;
    }
