    var res = string.Empty;
    var ids = new List<string>();
    using (var sr = new StreamReader(filepath, true))
    {
        var s = "";
        while ((s = sr.ReadLine()) != null)
        {
           if (s.StartsWith("START-OF-DATA"))
           {
               while (!s.StartsWith("END-OF-DATA"))
               {
                  if ( !s.StartsWith("START SECURITY") &&
                       !s.StartsWith("##") &&
                       !s.StartsWith("END SECURITY"))
                       {
                          res += s + System.Environment.NewLine;
                       }
                  if (s.StartsWith("#") && !s.StartsWith("##"))
                       ids.Add(s);
                   s = sr.ReadLine();
                }
                res += s;
           }
       }
    }
