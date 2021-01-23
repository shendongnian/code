    bool found = false;
    foreach (var i in test)
    {
      if (await TestIt(i))
      {
        found = true;
        break;
      }
    }
    if (found)
      Console.WriteLine("Contains numbers > 3");
    else
      Console.WriteLine("Contains numbers <= 3");
