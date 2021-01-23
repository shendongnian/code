                else if (typeof(IEnumerable<object>).IsAssignableFrom(property.PropertyType))
                {
                    var currentValue = (IEnumerable<object>)property.GetValue(item);
                    if (currentValue != null)
                        currentValue.Trim().ToList(); // Hack to enumerate it!
                }
            }
        }
        yield return item;
    }
