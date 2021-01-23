    var list =
        from entity in repository.GetAllEntities()
        group entity by entity.Region into regions
        let childrenOfRegions =
            from region in regions
            group region by region.SubRegion into subregions
            let countriesOfSubRegions =
                from subregion in subregions
                group subregion by subregion.Country into countries
                select new { Name = countries.Key }
            select new { Name = subregions.Key, Children = countriesOfSubRegions }
        select new { Name = regions.Key, Children = childrenOfRegions };  
