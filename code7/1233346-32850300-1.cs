    public abstract class BaseTrackedEntity : BaseEntity, IAuditableEntity, IChangeTrackedEntity
	{
      /* ... Other properties removed for clarity ... */
	  public ICollection<EntityHistory> Histories { get; set; }
	}
