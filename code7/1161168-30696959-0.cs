    public TEntity UpdateCollection<TEntity, TChildren>(myappContext dbContext, TEntity parentObject, Expression<Func<TEntity, 
                ICollection<TChildren>>> propertyExpression, ICollection<TChildren> objectChilren) where TEntity : class where TChildren : class
            {
    
                var parentEntityObject = dbContext.Entry<TEntity>(parentObject);
                List<TChildren> originalChildrenData = parentEntityObject.Collection(propertyExpression).CurrentValue.ToList();
    
                // Get key name
                var entityKeyName = GetKeyName(dbContext, originalChildrenData.Union(objectChilren).First());
    
                // Updating or removing existing items
                foreach (var originalItem in originalChildrenData)
                {
    
                    var originalValueKey = originalItem.GetType().GetProperty(entityKeyName).GetValue(originalItem, null);
                    var itemCompareExpression = GetCompareExpression<TChildren>(entityKeyName, originalValueKey);
    
                    // If entry was just modified, i have to update.
                    var newItem = objectChilren.FirstOrDefault(itemCompareExpression.Compile());
                    if (newItem != null)
                    {
                        dbContext.Entry<TChildren>(originalItem).CurrentValues.SetValues(newItem);
                        dbContext.Entry<TChildren>(originalItem).State = System.Data.EntityState.Modified;
                        // Remove item, because only 'new items' will be added after this loop
                        objectChilren.Remove(newItem);
                    }
                    else
                    {
                        dbContext.Entry<TChildren>(originalItem).State = System.Data.EntityState.Deleted;
                    }
                }
    
                // Adding new items
                foreach(var newItem in objectChilren)
                {
                    parentEntityObject.Collection(propertyExpression).CurrentValue.Add(newItem);
                }
    
                parentEntityObject.State = System.Data.EntityState.Modified;
                return parentEntityObject.Entity;
            }
