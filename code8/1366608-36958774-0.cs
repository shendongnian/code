    try
    {
       using(var textOut = new System.IO.StreamWriter(filename, true))
       {
           textOut.WriteLine("whatever..");
       }
    }
