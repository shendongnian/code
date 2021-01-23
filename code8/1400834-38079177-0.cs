    public virtual void Update(params T[] items)
    {
       using (var context = new Entities())
       {
           context.BulkUpdate(items);
       }
    }
