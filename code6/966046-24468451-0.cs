     System.IO.StreamWriter writer = null; 
     try
     {
         writer = new System.IO.StreamWriter("me00.txt", true);
         writer.WriteLine("Hey");
     }
     finally
     {
         if (writer != null)
            writer.Dispose();
     )
