    public override int SaveChanges()
    {
        var deletedCardIds = new List<int>();
        var chassises = ChangeTracker.Entries<Chassis>().Where(e => e.State == EntityState.Deleted);
        foreach (var chassis in chassises)
        {
            var slots = Slots.Where(s => s.ChassisId == chassis.Entity.Id).ToArray();
            foreach (var slot in slots)
            {
                if (slot.CardId.HasValue && !deletedCardIds.Contains(slot.CardId.Value))
                {
                    deletedCardIds.Add(slot.CardId.Value);
                }
            }
        }
    
        // Commits original transaction.
        var originalRowsAffected = base.SaveChanges();
    
        int additionalRowsAffected = 0;
        if (deletedCardIds.Count > 0)
        {
            // Opens new transaction.
            using (var newContext = new AppContext())
            {
                foreach (var cardId in deletedCardIds)
                {
                    var deletedCard = newContext.Cards.Find(cardId);
                    if (deletedCard != null)
                    {
                        newContext.Cards.Remove(deletedCard);
                    }
                }
    
                // Commits new transaction.
                additionalRowsAffected = newContext.SaveChanges();
            }
        }
    
        return originalRowsAffected + additionalRowsAffected;
    }
