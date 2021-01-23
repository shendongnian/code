    public class EntryN
    {
       public string id { get; set; }
       public string name { get; set; }
       public string email { get; set; }
       public string description { get; set; }
    }
    var entries = new List<EntryN>();
    using (var sl = new StreamReader(@"c:\YOURPATH.txt", true))
    {
        var entry = new EntryN();
        var line = string.Empty;
        while ((line = sl.ReadLine()) != null)
        {
           if (line.StartsWith("COD/ID:"))
              entry.id = line.Substring(8).Trim();
           else if (line.StartsWith("PRJ/NAME:"))
              entry.name = line.Substring(10).Trim();
           else if (line.StartsWith("PRJ/EMAIL"))
              entry.email = line.Substring(11).Trim();
           else if (line.StartsWith("PRJ/DESCRIPTION"))
              entry.description = line.Substring(17).Trim();
          else if (line.Trim() == string.Empty)
          {
              entries.Add(entry);
              entry = new EntryN();
          }
        }
        if (!entry.Equals(new EntryN()))
           entries.Add(entry);
        sl.Close();
    }
    var resulted = entries.Select(p => p.id + "|" + p.name + "|" + p.email + "|" + p.description).ToList();
