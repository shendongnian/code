    var s = new List<string>() {"Live", "Pending", "Expired"};
    var grouped = db.Post.Where(x => s.Contains(x.Status)) //Fitler for the statuses
                     .GroupBy(f => f.ModeratorId, po => po,
                                  (k, items) => new ModeratorPostViewModel
                                                {
                                                   Name = items.FirstOrDefault().User.Name,
                                                   Id=k, 
                                                   CountOfPosts = items.Count()
                                                }).ToList();
