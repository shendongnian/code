            // Gets entity type from specified namespace/assembly
            Type entityType = Type.GetType(string.Format("Your.NameSpace.{0},{1}", entityName, "Assembly.Name"));
            // Finds item to update based on its primary key value
            var entity = _dbContext.Find(entityType, entityKey);
            // Finds column to update preference for
            PropertyInfo propertyInfo = entity.GetType().GetProperty(entityField);
            // Set and update (date example given)
            propertyInfo.SetValue(entity, isOptIn ? (DateTime?)null : (DateTimeOffset?)DateTime.Now, null);
            _dbContext.SaveChanges();
