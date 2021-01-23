    Regex reg1 = new Regex("([0-9]* (out of) [0-9]*)");
    for (int i = 0; i < number; i++)
    {
      Console.WriteLine("the heading of the movie is {0}", header[i].InnerHtml);
      Match m = reg1.Match(header[i].InnerHtml);
    
      if (!m.Success)
      {
          return;
      }
      else
      {
          Regex reg2 = new Regex(@"\d+");
    	  m = reg2.Match(m.Value);
          string str1 = m.Value;
          string str2 = m.NextMatch().Value;
    
          if (!Int32.TryParse(str1, out index1))
          {
              return;
          }
          if (!Int32.TryParse(str2, out index2))
          {
              return;
          }
          Console.WriteLine("index1 = {0}", index1);
          Console.WriteLine("index2 = {0}", index2);
      }
}
