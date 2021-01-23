    private void SomeMethod()
    {
       List<int> inductionList = new List<int>() { 90, 120};
       int? introTime = 0;
       bool isEquelToNinety = false;
       foreach (var items in inductionList)
       {
          Console.WriteLine(isEquelToNinety=IsOK(items));
       }            
    }
    private bool IsOK(int? introTime)
    {            
       if (introTime == 90)
       {
          return true;
       }
       else
       {
          return false;
       }
    }
