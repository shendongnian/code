    void bool DoSomethingWithFile()
    {
      try
      {
         // Some code here
         System.IO.File.WriteAllLines()
         //some code here
         return true;
      }
      catch()
      {
         LogExeption();
         return false;
      }
    }
