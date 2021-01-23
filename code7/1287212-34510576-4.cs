    int Totalskip=0;
    for (int i = 0; i < totalColumnToShow; i++)
    {
      if(i>0){
      var skip = rowsPerColumn[i-1];
      Totalskip =Totalskip+ skip;
      }
      PagedList =GroupedLinksCategory.Select(y => new copiedList { Title = y.Title, ID = y.ID, Name= y.Name }).Skip(Totalskip).Take(rowsPerColumn[i]).ToList();
      foreach (var row in PagedList)
      {
         if (row.Name== "Test")
         {
            //my Logic
         }
         else
         {
             //my Logic
         }
      }
    }
