    public List<Post> GetPostsByTadId(int tagId)
    {
        using(var context=new MyContext())
        {
          return context.PostTags.Include(p=>p.Post)
                                 .Where(pt=> pt.TagId == tagId)
                                 .Select(pt=>pt.Post)
                                 .ToList();
        }
    }
