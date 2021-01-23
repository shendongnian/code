    var selectedTagIds = dc.Tags.Where(tag => _SelectedTags.Contains(tag.Name)).Select(x => x.TagId);
    var tagPosts = dc.Posts
        .Where(post => post.Status == 1)
        .Where(post => 
          !(from selectedTag in selectedTagIds
            join tag in post.PostTags on selectedTag equals tag.TagId into postTags
            from tag in postTags.DefaultIfEmpty()
            where tag.TagId == null
            select 1).Any());
    return tagPosts.OrderByDescending(p => p.DateAdded).Take(numPosts).ToList();
