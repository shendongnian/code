    using (ModelContainer context = new ModelContainer())
    {
        foreach(var hazaa in newbies)
        {
            context.Attach(hazaa);
            hazaa.Killed = DateTime.Now; // Will mark hazaa as modified
            
            context.Add(new Hazaa { Linky = hazaa.Linky };
            context.Hazaas.Add(newbie);
        }
    }
    context.SaveChanges();
