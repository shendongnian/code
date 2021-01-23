    int value;
    if(Int32.TryParse(data[0], out value))
    {
      accountNumber = value;
    }
    else
    {
      //Something when data[0] can't be turned into an int.
      //You'll have to decide this logic.
    }
