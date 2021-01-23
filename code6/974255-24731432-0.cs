    const int Max_Capacity = 6;
    
    if (UrlList.Count >= Max_Capacity) 
      UrlList.RemoveAt(0); // <- oldest (first) item should be removed
    
    UrlList.Add(uri.ToString());
    ...
    // Printing out the lastest 3 items:
    int start = UrlList.Count <= 3 ? 0 : UrlList.Count - 3;
    
    for (int i = start; i < UrlList.Count; ++i)
      Console.Out.WriteLine(UrlList[i]);
  
