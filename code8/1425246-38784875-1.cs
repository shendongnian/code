    private void PreparePropertyGrid()
    {
        PropertyDefinitionCollection propertyDefinitions = new PropertyDefinitionCollection();
        // This is how I determine 
        var mainPropertySet = this.currentPropertySelection.FirstOrDefault();
        if (mainPropertySet != null)
        {
            var properties = TypeDescriptor.GetProperties(mainPropertySet.GetType());
            // Allowing for multiple selection, if on further iterations through the selected items we will remove properties that do not exist in both PropertySets
            bool firstIteration = true;
            foreach (var x in this.currentPropertySelection)
            {
                foreach (var p in properties.Cast<PropertyDescriptor>())
                {
                    if (!firstIteration)
                    {
                        // Perhaps we should be checking a little more safely for TargetProperties but if the collection is empty we have bigger problems.
                        var definition = propertyDefinitions.FirstOrDefault(d => string.Equals(d.TargetProperties[0] as string, p.Name, StringComparison.Ordinal));
                        // Someone in the selection does not have this property so we can ignore it.
                        if (definition == null)
                        {
                            continue;
                        }
                        // If this item doesn't have the property remove it from the display collection and proceed.
                        var localProperty = x.GetType().GetProperty(p.Name);
                        if (localProperty == null)
                        {
                            propertyDefinitions.Remove(definition);
                            continue;
                        }
                        // There is actually no point in proceeding if this is not the first iteration and we have checked whether the property exists.
                        continue;
                    }
                    string category = p.Category;
                    string description = p.Description;
                    string displayName = p.DisplayName ?? p.Name;
                    int? displayOrder = null;
                    bool? isBrowsable = p.IsBrowsable;
                    bool? isExpandable = null;
                    var orderAttribute = p.Attributes[typeof(PropertyOrderAttribute)] as PropertyOrderAttribute;
                    if (orderAttribute != null)
                    {
                        displayOrder = orderAttribute.Order;
                    }
                    var expandableAttribute = p.Attributes[typeof(ExpandableObjectAttribute)] as ExpandableObjectAttribute;
                    if (expandableAttribute != null)
                    {
                        isExpandable = true;
                    }
                    propertyDefinitions.Add(new PropertyDefinition
                    {
                        Category = category,
                        Description = description,
                        DisplayName = displayName,
                        DisplayOrder = displayOrder,
                        IsBrowsable = isBrowsable,
                        IsExpandable = isExpandable,
                        TargetProperties = new[] { p.Name },
                    });
                }
            }
            firstIteration = false;
            this.propertyGrid.PropertyDefinitions = propertyDefinitions;
        }
    }
