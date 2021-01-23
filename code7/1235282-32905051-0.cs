    public ActionResult Index()
    {
        var livePostModel = new PostsViewModel
        {
            Posts = new Post[]
            {
                new Post
                {
                    Created = "Today",
                    CreatedDateTime = DateTime.UtcNow,
                    Header = "Todays Post",
                    Key = Guid.NewGuid().ToString(),
                    Message = "Todays message",
                    Modified = string.Empty,
                    PostId = Guid.NewGuid().ToString()
                },
                new Post
                {
                    Created = "Yesterday",
                    CreatedDateTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(1)),
                    Header = "Yesterdays Post",
                    Key = Guid.NewGuid().ToString(),
                    Message = "Yesterdays message",
                    Modified = string.Empty,
                    PostId = Guid.NewGuid().ToString()
                },
                new Post
                {
                    Created = DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)).ToString("D"),
                    CreatedDateTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)),
                    Header = DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)).ToString("D") + " Post",
                    Key = Guid.NewGuid().ToString(),
                    Message = DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)).ToString("D") + " message",
                    Modified = string.Empty,
                    PostId = Guid.NewGuid().ToString()
                },
                new Post
                {
                    Created = DateTime.UtcNow.Subtract(TimeSpan.FromDays(3)).ToString("D"),
                    CreatedDateTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(3)),
                    Header = DateTime.UtcNow.Subtract(TimeSpan.FromDays(3)).ToString("D") + " Post",
                    Key = Guid.NewGuid().ToString(),
                    Message = DateTime.UtcNow.Subtract(TimeSpan.FromDays(3)).ToString("D") + " message",
                    Modified = string.Empty,
                    PostId = Guid.NewGuid().ToString()
                },
            }
        };
        this.ViewBag.Json = JsonConvert.SerializeObject(livePostModel);
    
        return View();
    }
