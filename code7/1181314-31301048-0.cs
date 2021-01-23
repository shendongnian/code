    public class MyClass 
    {
      .............
      string a;
      string b;
      public ReadTheData(Stream stream)
      {
        try
        {
            TextReader tr = new StreamReader(stream);
    
            a = tr.ReadLine();
            b = tr.ReadLine();
            tr.Close();
        }
        catch (Exception ex)
        {
            // awful practice... Don't eat all exceptions
            error = GetError(ex);
        }
        if (error != "") {
           // whatever log infrastructure you have, need to be mock-able for tests 
            Logger.Log(error);
        }
      }
    }
