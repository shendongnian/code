        private void SetAttachedEntityValues(T attachedEntity, T entity, string[] excludePropertyNames)
        {
            var properties = typeof(T).GetProperties().Where(x => !excludePropertyNames.Contains(x.Name)).ToList();
            foreach(var property in properties)
            {
                var propertyValue = ObjectUtil.GetPropertyValue(entity, property.Name);
                ObjectUtil.SetPropertyValue(attachedEntity, property.Name, propertyValue);
            }
        }
