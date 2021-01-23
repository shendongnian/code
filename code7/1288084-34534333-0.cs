     string ParaCol = "2,3";
     string[] iCol = ParaCol.split(',');
     string[] Table1Colms = {"Items", "Sizes", "SizeM","SizeL"}; 
     
     string Columns = "";
     for(int i =0 ; i < Table1Colms.Count() ; i++)
     {
        if(iCol.contains(i.ToString()))
    	{
    		Columns = Columns  != ""? Columns + ", " +  Table1Colms[i] : Columns + Table1Colms[i];
    	}
     }
    
    SqlCommand cm = new SqlCommand("SELECT "+ Columns +" FROM Table1 where Items = '" +s+ "' "); 
