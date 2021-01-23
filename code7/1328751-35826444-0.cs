    IList<String> Collection3;
    
    for(int i = 0 ; i < Collectio2.Count ; i++)
    {
       foreach(String str in Collection1)
       {
          if(str.Contains(Collection2[i]))
          {
             Collection3.Add(str);
          }
       }
    }
