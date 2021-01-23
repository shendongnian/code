    void PropertyGrid_PreparePropertyItem(object sender, PropertyItemEventArgs e)
    {
        foreach (var x in this.currentPropertySelection)
        {
            // If we are in read-only mode do not allow the editing of any property.
            if (this.IsReadOnly)
            {
                e.PropertyItem.IsEnabled = false;
            }
            string propertyName = ((PropertyItem)e.PropertyItem).PropertyDescriptor.Name;
            PropertyInfo property = x.GetType().GetProperty(propertyName);
            var propertyItem = e.Item as PropertyItem;
            // If the property doesn't exist then check to see if it is on an expandable item.
            if (property == null)
            {
                property = propertyItem.Instance.GetType().GetProperty(propertyName);
            }
            bool hasProperty = property != null;
            if (hasProperty)
            {
                var browsableAttribute = property.GetCustomAttribute<BrowsableAttribute>(true);
                if (browsableAttribute != null &&
                    !browsableAttribute.Browsable)
                {
                    e.PropertyItem.Visibility = Visibility.Collapsed;
                    e.Handled = true;
                    break;
                }
                var visibilityAttribute = property.GetCustomAttribute<VisibilityAttribute>(true);
                if (visibilityAttribute != null)
                {
                    e.PropertyItem.Visibility = visibilityAttribute.Visibility;
                    e.Handled = true;
                }
                var independentAttribute = property.GetCustomAttribute<IndependentAttribute>(true);
                // If a property is marked as being independent then we do not allow editing if multiple items are selected
                if (independentAttribute != null &&
                    this.currentPropertySelection.Length > 1)
                {
                    e.PropertyItem.IsEnabled = false;
                    e.Handled = true;
                    break;
                }
            }
        }
    }
