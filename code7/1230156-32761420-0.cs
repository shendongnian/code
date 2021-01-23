    public static List<stuff> Stuff;
    using (var context = new StuffContext()) 
    { 
        stuff = new List<stuff>();
        stuff = (from r in context.Stuff
                .Include(s => s.MoreStuff).Include(s => s.EvenMoreStuff)
                select r).ToList(); 
    }
