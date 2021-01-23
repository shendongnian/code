        public static void MapObjects( object source,  object destiny)
        {
            var modelPropertiesName = new HashSet<string>(source.GetType().GetProperties().Select(x => x.Name));
            var entityProperties = destiny.GetType().GetProperties();
            var propertyList = entityProperties.Where(p => modelPropertiesName.Contains(p.Name))
                           .ToList();
            foreach (var prop in propertyList)
            {
                var modelProperty = source.GetType().GetProperty(prop.Name);
                var value = modelProperty.GetValue(source);
                prop.SetValue(destiny, value, null);
            }
        }
