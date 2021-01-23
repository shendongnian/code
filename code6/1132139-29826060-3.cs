	public DBConceptAnswerExcludedAnswerMapping()
	{
		HasRequired(t => t.Entity).WithMany(t => t.ExcludingEntities).HasForeignKey(t => t.EntityID);
		HasRequired(t => t.ExcludedEntity).WithMany(t => t.ExcludedFromEntities).HasForeignKey(t => t.ExcludedEntityID);
	}
