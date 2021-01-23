    var nameOrder = new[] { 
    	new {Name = "Chris", Order = 1}
    	, new {Name = "Adam", Order = 2}
    	, new {Name = "Nick", Order = 3}
    };
    
    lstNames.Join(nameOrder, lstName => lstName, nameOrd => nameOrd.Name, (Name, nameOrd) => new { Name, nameOrd.Order }).OrderBy(o => o.Order);
