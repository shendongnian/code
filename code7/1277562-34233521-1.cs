    public class Category : Entity
    {
        public Guid CategoryId { get; set; }        
        public virtual ICollection<UserProfile> UserProfiles { get; set; }     
        public string Name { get; set; }
    }
    
    public class UserProfile : Entity
    {
        public Guid UserProfileId { get; set; }
    
        public virtual ICollection<Category> Categories { get; set; }
        public string Name { get; set; }
    }
    
    var context = new OfContext();
    context.Configuration.AutoDetectChangesEnabled = false;
    var userProfile = context.UserProfiles.Include(up => up.Categories).FirstOrDefault(up => up.UserProfileId == new Guid("XXXX"));
    var category = context.Categories.FirstOrDefault(c => c.CategoryId == new Guid("XXXX"));
    userProfile.Categories.Add(category);
    userProfile.FirstName = "Updated";
    context.Entry(userProfile).State = EntityState.Modified;
    context.ChangeTracker.DetectChanges();
    context.SaveChanges();
                    
