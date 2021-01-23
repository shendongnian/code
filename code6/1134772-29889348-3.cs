    var id = string.Empty;
    var name = string.Empty;
    var email = string.Empty;
    var description = string.Empty;
    using (var sw = new StreamWriter(@"OUTPUT_FILE", false, Encoding.UTF8))
    {
        using (var sl = new StreamReader(@"INPUT_FILE", true))
        {
           var line = string.Empty;
           while ((line = sl.ReadLine()) != null)
           {
               if (line.StartsWith("COD/ID:"))
                  id = line.Substring(8).Trim();
               else if (line.StartsWith("PRJ/NAME:"))
                  name = line.Substring(10).Trim();
               else if (line.StartsWith("PRJ/EMAIL"))
                  email = line.Substring(11).Trim();
               else if (line.StartsWith("PRJ/DESCRIPTION"))
                  description = line.Substring(17).Trim();
               else if (line.Trim() == string.Empty)
               {
                   sw.WriteLine(string.Format("{0}|{1}|{2}|{3}", id, name, email, description));
                   id = name = email = description = string.Empty;
                }
            }
            if (!new string[] {id, name, email, description}.Any(p => string.IsNullOrWhiteSpace(p)))
                sw.WriteLine(string.Format("{0}|{1}|{2}|{3}", id, name, email, description));
            sl.Close();
         }
         sw.Close();
     }
