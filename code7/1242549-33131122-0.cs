    var allitems =
    	_programContentService
    	.Products
    	.Select(x => new { x.FullName, x.TypeId, x.Id })
    	.Union(
    		_programContentService
    		.Programs
    		.Select(x => new { x.FullName, x.TypeId, x.Id }))
    	.Join(
    		_programContentService.SpecialtyMembers,
    		type => new { type.TypeId, type.Id },
    		member => new { TypeId = member.ItemType, Id = member.ItemId },
    		(type, member) => new { type.FullName, member.Category })
    	.Join(
    		_programContentService.Specialties,
    		x => x.Category,
    		specialty => specialty.Id,
    		(x, specialty) => new { x.FullName, specialty.CategoryName })
    	.GroupBy(x => x.FullName)
    	.AsEnumerable()
    	.Select(x => new SelectListItem 
    		{ 
    			Name = x.FullName, 
    			Genre = String.Join(",", x)
    		});
