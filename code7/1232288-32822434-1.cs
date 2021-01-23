            //Get the collection property
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.Name == "Props")
                {
                    foreach (var item in (IEnumerable)property.GetValue(type, null))
                    {
                        //Because props is a collection, Getting the type and property on each pass was essential
                        var propertyName = item.GetType().GetProperty("PropertyName").GetValue(item, null);
                        var newValue = item.GetType().GetProperty("NewValue").GetValue(item, null);
                        var oldValue = item.GetType().GetProperty("OldValue").GetValue(item, null);
                       sbDescription.AppendLine(strDescriptionVals
                           .Replace("{0}", (propertyName != null) ? propertyName.ToString() : "" + ", "));
                       sbAllNotes.AppendLine(strAllNotes
                           .Replace("{0}", (propertyName != null) ? propertyName.ToString() : "")
                           .Replace("{1}", (newValue != null) ? newValue.ToString() : "")
                           .Replace("{2}", (oldValue != null) ? oldValue.ToString() : ""));
                    }
                }
            } 
