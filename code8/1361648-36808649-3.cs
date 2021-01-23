    public Action GetFile(int id)
    {
        using(context = new YourDbContext())
        {
            var file = context.Files.FirstOrDefault(p => p.Id == id);
        }
        return View(file);
    }
