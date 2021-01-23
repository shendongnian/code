    //From the Database (assuming something like this)
    var result = Enumerable.Range(1, 1).Select(i => new { SehirId = 1, uniKodu =1 });
    
    var dict = result
    	.GroupBy(r => r.uniKodu)
    	.ToDictionary(g => g.Key, g => g.ToDictionary(r => r.SehirId, g.Sum(r => r.SehirId)));
