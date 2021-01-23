    var orderListToDelete = context.Pages.Where(o => o.Name == pName).ToList();
    foreach (var u in orderListToDelete)
    {
        context.Pages.Remove(u);
    }
    context.SaveChanges();
