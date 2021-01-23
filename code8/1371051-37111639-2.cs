    var result = Products.AsEnumerable().Where(g => g.Name == "A").ToList();
    int userInput =4;
    var total = 0;
    var selectList = new List<product>();
    for (int i = 0; i < result.Count; i++)
    {
       for (int j = i; j < result.Count; j++)
        {
          if (total + result[j].Quantity <= userInput)
          {
             total += result[j].Quantity;
             selectList.Add(result[j]);
             break;
           }
           else if (total + result[j].Quantity < userInput)
           {
              total += result[j].Quantity;
              selectList.Add(result[j]);
            }
         }
         if (total == userInput)
           break;
         else
         {
            total = 0;
            selectList = new List<product>();
          }
    }
    if(userInput!=total)
     selectList = new List<product>();
