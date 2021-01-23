            var validItemsMethodSyntax = db.Where(x => x.IsValid).OrderBy(x => x.Count);
            var nonValidItemsMethodSyntax = db.Where(x => x.IsValid == false).OrderBy(x => x.CreateDate);
            var combinedMethodSyntax = validItemsMethodSyntax
                .Concat(nonValidItemsMethodSyntax)
                .ToList();
