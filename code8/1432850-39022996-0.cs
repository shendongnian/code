    public interface IUser
    {
        int Id { get; set; }
    }
    public class RestaurantGuest : IUser
    {
        public int Id { get; set; }
    }
    public class Visit
    {
        public int Id { get; set; }
        public virtual GuestFactory Guest { get; set; }
        public int GuestId { get; set; }
    }
    public class GuestFactory: IUser
    {
        public int Id { get; set; }
        public IUser Build()
        {
            return new RestaurantGuest { Id = this.Id };
        }
    }
    builder.VersionedEntity().HasMany()
           .WithRequired(v => v.Restaurant).HasForeignKey(v => v.RestaurantId);
