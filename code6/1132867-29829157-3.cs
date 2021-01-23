    // ... initialize model.
	foreach (var domainModel in model.Domaines)
	{
		// Assuming the display member you want to truncate is called `DisplayString`.
        // See linked questions for Truncate() implementation.
		domainModel.DisplayString = domainModel.DisplayString.Truncate(18); 
	}
    // Assuming the `Domaines` type has a `Value` member that indicates its value.
	var selectList = new SelectList(model.Domaines, "Value", "DisplayString");
    // Add a `public SelectList DomainSelectList { get; set; }` to your model.
	model.DomainSelectList = selectList;
	return View(model);
    
