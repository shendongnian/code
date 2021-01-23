	if(doc.Descendants("Charge").Any())
	{
	    var FarePrice = doc.Descendants("Charge")
                    .Where(x => x.Descendants("Name").First().Value.Equals("Fare")).First().Element("Price").Value;
				
        var Sum = doc.Descendants("Charge")
                    .Select(x => Convert.ToDouble(x.Descendants("Price").First().Value))
                    .Sum();  	
		Console.WriteLine("Fare price:{0} Sum:{1}",FarePrice,Sum);
	} 
