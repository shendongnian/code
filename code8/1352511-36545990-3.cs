    using (var context = new SomeContext())
    {
        var change = context.SomeTable.First(o => o.Id == item.Id);
        change.Comment = item.Comment;
        ...
        context.SubmitChanges();
    }
