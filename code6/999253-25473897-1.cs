    var blogPosts = _repo
             .GetPosts()
             .OrderByDescending(o => o.PostedOn)
             .Take(25)
             .AsEnumerable()
             .Select(x => new BlogPost 
                          { 
                             Description = x.Description.Substring(0, 20)),
                             // set other properties
                          });
