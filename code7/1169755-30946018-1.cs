    var tagPosts = dc.Posts.Where(post => post.Status == 1);
    foreach (var selectedTag in _SelectedTags)
    {
        tagPosts = tagPosts.Where(post => post.PostTags.Any(tag => tag.Name == selectedTag));
    }
    tagPosts = tagPosts.OrderByDescending(p => p.DateAdded).Take(numPosts).ToList();
