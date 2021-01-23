  	public void UpdateRelatedEntityCollection<T>(IEnumerable<T> existingEntities, IEnumerable<T> updatedEntities) where T : BaseRelatedEntity
        {
            var addedEntities = updatedEntities.Except(existingEntities, x => x.Id);
            var deletedEntities = existingEntities.Except(updatedEntities, x => x.Id);
            var modifiedEntities = updatedEntities.Except(addedEntities, x => x.Id);
            addedEntities.ToList<T>().ForEach(x => UnitOfWork.Context.Entry(x).State = EntityState.Added);
            deletedEntities.ToList<T>().ForEach(x => UnitOfWork.Context.Entry(x).State = EntityState.Deleted);
            foreach (var entity in modifiedEntities)
            {
                var existingEntity = UnitOfWork.Context.Set<T>().Find(entity.Id);
                if (existingEntity != null)
                {
                    var contextEntry = UnitOfWork.Context.Entry(existingEntity);
                    contextEntry.CurrentValues.SetValues(entity);
                }
            }
        }
