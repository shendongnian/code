     var numberOfDuplicates = this.UnitOfWork.Repository<Models.SUB>()
                .Queryable().GroupBy(x => x.Name)
                .Where(x => x.Count() > 1)
                .Select(x => new { Name = x.Key, Count = x.Count() });
    foreach(var dup in numberOfDuplicates)
    {
         Console.WriteLine($"Name = {dup.Name } ** Counter = {dup.Count}");
    }
