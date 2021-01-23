    public bool IsValid(int number)
    {
       var numberAsString = number.ToString();
       foreach (var digit in numberAsString)
       {
          switch (digit)
          {
             case '2':
             case '5':
             case '8':
             case '9':
                return false;
          }
       }
       return true;
    }
