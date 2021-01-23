	public class Entity
	{
		public int ID { get; set; }
		public virtual ICollection<EntityExcludedEntity> ExcludingEntities { get; set; }
		public virtual ICollection<EntityExcludedEntity> ExcludedFromEntities { get; set; }
	}
