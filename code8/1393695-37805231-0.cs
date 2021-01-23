    var copyitems = doc.Descendants(application)   // Read all descendants    
        .SelectMany(x => x.Elements("Test"))
        .Select(s =>
        {
            return new 
                   { 
                         Source = s.Element("Source").Value.Replace("@SRCDIR@", ""),
                         Destination =s.Element("Destination").Value.Replace("@INSTDIR@", "") 
                   };
        })
        .ToList();
