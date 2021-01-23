    try
    {
       Console.WriteLine(cell.Value2.ToString() != "" ? cell.Value2.ToString(): "null!");
    }
    catch(exception e)
    {
      Console.WriteLine(e.Argument);
    }
