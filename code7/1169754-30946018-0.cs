    var tagPosts = dc.Posts
                     .Where(post => post.Status == 1)
                     .Where(post => 
                         !_SelectedTags.Any(tag =>
                             !post.PostTags.Any(postTag => postTag.Name == tag)
                     .OrderByDescending(p => p.DateAdded)
                     .Take(numPosts).ToList();
