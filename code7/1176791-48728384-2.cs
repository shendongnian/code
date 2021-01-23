     StringBuilder sb = new StringBuilder();
         sb.Append("Ola~");
         sb.Append("Jola~");  
         sb.Append("Zosia~");
     //foreach loop ver sb object
      foreach(string s in sb.ToString().Split('~')){
             Console.WriteLine(s);
              }
