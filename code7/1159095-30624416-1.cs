    public class ViewBase<TEntity, TSchema>
        where TEntity : Entity<TSchema>
        where TSchema : EntitySchema
    {
        public TEntity Entity { get; set; }
    }
    public class ContactView : ViewBase<Contact, ContactEntitySchema>
    {
        public ContactView()
        {
        }
    }
    public class ProductView : ViewBase<Entity<EntitySchema>, EntitySchema>
    {
        public ProductView()
        {
        }
    }
