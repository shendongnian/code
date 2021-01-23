    // check for duplicate entries
    foreach (var tag in post.Tags.ToList()) 
    {         
        var dupeTag = uwork.TagRepository.GetAll().FirstOrDefault(t => t.Name == tag.Name);
    
        //Replace tag with the dupe if found
        if(dupeTag != null)
        {
            post.Tags.Remove(tag);
            post.Tags.Add(dupeTag);
        }
    }
