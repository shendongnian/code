    public Site GetSiteById(int id)
    {
        using(var context = new SiteContext())
        {
            return context.Sites.FirstOrDefault(i => i.Id == id);
        }
    }
