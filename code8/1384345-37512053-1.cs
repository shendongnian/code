        //Your Xml string goes into _xml
		var doc = XDocument.Parse(_xml);
		
		var baseGrouping = doc.Descendants("Votes")
            .SelectMany(a=>a.Descendants()
            .Select(b=>new{ personId = a.Attribute("id").Value, vote = int.Parse(b.Value) }));
		
		var aggregates = baseGrouping.GroupBy(a=>a.personId)
            .Select(a=>new { 
                         personId=a.Key, 
                         count = a.Count(), 
                         sum = a.Sum() 
            });
