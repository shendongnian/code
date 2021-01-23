    var idAndDates = yourDbContext.Posts
                            .Select(g => new { Id = g.Id, Created = g.CreatedDate}).ToList();
    var postIds = idAndDates
               .Where(g => DateTime.Parse(g.Created) > new DateTime(2015, 2, 3))
               .Select(x => x.Id);
    var filterdPosts= yourDbContext.Posts.Where(x => postIds.Contains(x.Id)).ToList();
