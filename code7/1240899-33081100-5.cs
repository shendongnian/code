    using (DataClassesDataContext dc = new DataClassesDataContext())
    {
        var sPlant = (from p in dc.Plants where p.Name == plantName
            select p).ToList().Select(p => new Plant
            {
                Name = p.Name,
                LatinName = p.LatinName, 
                Habitat = p.Habitat,
                LeafHarvesting = p.LeafHarvesting,
                FlowerHarvesting = p.FlowerHarvesting,
                FruitHarvesting = p.FruitHarvesting,
                RootHarvesting = p.RootHarvesting,
                Morphology = p.Morphology,
                Pharmacology = p.Pharmacology,
                Img = p.Img,
                GPSCoordinates = p.GPSCoordinates
            }).First(); // or FirstOrDefault() if plantName can refer to no plant at all
    }
