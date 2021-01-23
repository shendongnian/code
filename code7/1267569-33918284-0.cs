    List<string> s = new List<string>();
    s.Add("abcdefg");
    s.Add("hijklm");
    s.Add("nopqrs");
    s.Add("tuvwxyz");
    if(s.Any( l => l.Contains("tuv") ))
    {
       Console.Write("macthed");
       int index= -1;
       foreach(string item in s)
       {
         if(item.IndexOf("tuv")>=0)
         {
           index = s.IndexOf(item);
         }
                    
       }
       Console.Write(s[index]);
      }
      else
        Console.Write("unmacthed");
     }
