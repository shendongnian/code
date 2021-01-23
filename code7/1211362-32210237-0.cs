    Func<string, string> GetFirstStringPart = title => 
       {
          if(string.IsNullOrEmpty(title))
              return null;  // or string.Empty;
          string[] stringParts = title.Split(',');
          if(stringParts.Any())
              return stringParts.First().Trim();
          else
              return null;  // or string.Empty;
      };
     foreach (var record in customersandproducts)
     {
         records.Add(new SpreadList()
         {
             Name = WebUtility.HtmlDecode(record.Name),
             Title = GetFirstStringPart(record.Title),
             ...
             . etc .                
