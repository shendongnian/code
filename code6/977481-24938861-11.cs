    public void CanCascadeDeleteCards()
    {
        using (var context = new EfContext())
        {
            // We have to tell Entity Framework of the maximum depth of the 
            // card-->card relationship using the Include method
            var chassis = context.CardContainers.OfType<Chassis>()
                .Include(x => x.Cards.Select(y => y.Cards))
                .First();
            context.CardContainers.Remove(chassis);             
            context.SaveChanges();
        }
    }
