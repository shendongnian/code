    public void UpdateProperties(Tuple<string, bool?, Visibility?>[] newPropertyStates)
    {
        // Note this currently works under the assumption that an Item has to be selected in order to have a value changed.
        this.suppressPropertyUpdates = true;
        foreach (var property in newPropertyStates)
        {
            string propertyName = property.Item1;
            string[] splits = propertyName.Split('.');
            if (splits.Length == 1)
            {
                this.propertyGrid.Properties.OfType<PropertyItem>()
                                            .Where(p => string.Equals(p.PropertyDescriptor.Name, propertyName, StringComparison.Ordinal))
                                            .Map(p =>
                {
                    if (property.Item2.HasValue)
                    {
                        p.IsEnabled = property.Item2.Value;
                    }
                    if (property.Item3.HasValue)
                    {
                        p.Visibility = property.Item3.Value;
                    }
                });
            }
            else // We currently don't expect to go any lower than 1 level.
            {
                var parent = this.propertyGrid.Properties.OfType<PropertyItem>()
                                                         .Where(p => string.Equals(p.PropertyDescriptor.Name, splits[0], StringComparison.Ordinal))
                                                         .FirstOrDefault();
                if (parent != null)
                {
                    parent.Properties.OfType<PropertyItem>()
                                     .Where(p => string.Equals(p.PropertyDescriptor.Name, splits[1], StringComparison.Ordinal))
                                     .Map(p =>
                    {
                        if (property.Item2.HasValue)
                        {
                            p.IsEnabled = property.Item2.Value;
                        }
                        if (property.Item3.HasValue)
                        {
                            p.Visibility = property.Item3.Value;
                        }
                    });
                }
            }
        }
        this.suppressPropertyUpdates = false;
    }
