    foreach (var userItem in UserItems)
    {
     // RVD is provided by routing framework and it gives a dictionary 
     // of the object property names and values, without us doing 
     // anything funky. 
     var userItemDictionary= new RouteValueDictionary(userItem);
    }
