    var list = new List<overviewModel>();
    list.Add(new overviewModel() { Id = Guid.NewGuid(), Position = 3, Url = "url" });
    list.Add(new overviewModel() { Id = Guid.NewGuid(), Position = 1, Url = "url" });
    list.Add(new overviewModel() { Id = Guid.NewGuid(), Position = 4, Url = "url" });
    list.Add(new overviewModel() { Id = Guid.NewGuid(), Position = 2, Url = "url" });
    list.Add(new overviewModel() { Id = Guid.NewGuid(), Position = 5, Url = "url" });
    var PageId = list[2].Id;
    var triple = list.Where(e => e.Id == PageId).SelectMany(e => new[] 
               {
                   list.FirstOrDefault(q => q.Position == e.Position - 1), 
                   e, 
                   list.FirstOrDefault(q => q.Position == e.Position + 1)
               }).ToArray();
