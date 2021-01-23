    var result = await collection
                 .Find(x => x.GeneralStructures.Any(y => y.StructureProperties.Any(z => z.UserId == ObjectId.Parse(userId))))
                 .Project(
                    p => new
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Structure = p.GeneralStructures.FirstOrDefault(x => x.StructureProperties.Any(z => z.UserId == ObjectId.Parse(userId)))
                    })
                    .FirstOrDefaultAsync();
    result.Structure.StructureProperties = result.Structure.StructureProperties.Where(x => x.UserId == ObjectId.Parse(userId)).ToList();
