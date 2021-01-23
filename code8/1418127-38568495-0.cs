     public bool IsDevidedByTwo(int number)
     {
        if(number % 2 == 0)
           return true;
        return false ;
     }
    List<int> DevidedByTwoList = new List<int>;
    foreach(var number in RandomIntsList)
    {
       if(IsdevidedByTwo(number)) DevidedByTwoList.Add(number);
    }
