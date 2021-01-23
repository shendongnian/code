    var result = Products.AsEnumerable().Where(g => g.Name == "A").ToList();
    int userInput =4;
    var total = 0;
    var selectList = new List<product>();
    foreach (var item in result)
    {
       if (total + item.Quantity <= userInput)
       {
          total += item.Quantity;
          selectList.Add(item);
          break;
        }
        else if (total + item.Quantity < userInput)
        {
           total += item.Quantity;
           selectList.Add(item);
         }
    }
    if(userInput!=total)
     selectList = new List<product>();
