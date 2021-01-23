    public ActionResult BattleNPC(int arenaId)
    {
      var model = var arenaModel = ctx.Arenas.FirstOrDefault(a => a.Id == arenaId);
      var character = model.Character; // <-- Null
    }
