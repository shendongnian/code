    public DbSet<promotion > promotion { get; set; }
    
    public DbSet<PromotionsClaimed> PromotionsClaimed{ get; set; }
    
    Context.promotion.Include(o => o.PromotionsClaimed).FirstOrDefault(s => s.Id == USERID);
