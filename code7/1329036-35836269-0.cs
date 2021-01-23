            foreach (var propertyName in entry.CurrentValues.PropertyNames)
            {
                var value = entry.CurrentValues[propertyName];
                if (value != null)
                {
                    entry.Property(propertyName).IsModified = true;
                }
                else
                {
                    entry.Property(propertyName).IsModified = false; //The else condition
                }
            }
