    List<string> ages = new List<string> { "twentyOne", "FortySix", "FortySix", "FiftyFive", "SevenTeen", "twentyOne", "FiftyFive", "FiftyFive" };
    List<int> realAges = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };  
    
    ages = ages.Distinct();
    DataTable table = some table you use
    DataRow row = table.NewRow();
  
     for (int i = 0;i < ages.Count(); ++i)
     { 
         if (realAges.Count() < i)
         {
            row[ages[i]] = realAges[i]
         }
     }
