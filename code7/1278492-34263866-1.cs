    using System.Data.Entity;
    var entities = mainContext
        .EntityToOrder
        .Include(x => x.OtherEntity)
        .OrderBy(e => e.OtherEntity.Name)
        .Skip(startIndex)
        .Take(pageSize)
        .ToList();
