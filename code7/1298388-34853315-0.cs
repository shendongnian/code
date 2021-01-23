    using (var db = new MyContext())
    {
         db.Players.AddOrUpdate(player);
         db.SaveChanges();
         // Get the actually tracked player:
         player = db.Players.Local.Single(p => p.Id == player.Id);
    }
