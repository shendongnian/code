     protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
    
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
     
            var BArray = context.BList.ToArray();
            var AArray = context.AList.ToArray();
            for (int i = 0; i < BArray.Length; i++)
            {
                if (BArray.Length == AArray.Length)
                {
                    BArray[i].AID = AArray[i].AId;
    
                }
    
            }
            context.SaveChanges();
        }
    
