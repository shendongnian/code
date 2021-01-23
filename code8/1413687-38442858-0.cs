    var allitems = _contentService.Products
        .Select(x => new {x.FullName, x.TypeId, x.Id, x.Sku})
        .GroupJoin(_contentService.AuthorAssignments,
            p => p.Id,
            aa => aa.Id,
            (p, aa) => new 
            { 
                p.Sku, 
                p.FullName, 
                p.Id, 
                p.TypeId, 
                AuthorId = aa.Select(x => x.AuthorId).FirstOrDefault()
            })
        .GroupJoin(_contentService.Authors,
            p => p.AuthorId,
            a => a.Id,
            (p, a) => new 
            { 
                p.FullName, 
                p.TypeId, 
                p.Id,
                p.Sku, 
                Author = a.Select(x => x.Author).FirstOrDefault()
            });
