    public override int SaveChanges()
    {
        var deletedCardIds = new List<int>();
        var chassises = ChangeTracker.Entries<Chassis>().Where(e => e.State == EntityState.Deleted);
        foreach (var chassis in chassises)
        {
            var cardIds = Slots.Where(s => s.ChassisId == chassis.Entity.Id)
                .Where(s => s.CardId.HasValue)
                .Select(s => s.CardId.Value)
                .ToArray();
            deletedCardIds.AddRange(cardIds);
        }
    
        int originalRowsAffected;
        int additionalRowsAffected;
        using (var transaction = new TransactionScope())
        {
            originalRowsAffected = base.SaveChanges();
    
            deletedCardIds.Distinct().ToList()
                .ForEach(id => Entry(new Card { Id = id }).State = EntityState.Deleted);
            additionalRowsAffected = base.SaveChanges();
    
            transaction.Complete();
        }
    
        return originalRowsAffected + additionalRowsAffected;
    }
