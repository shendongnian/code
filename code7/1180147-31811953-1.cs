    private void propertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
    {
        // get the descriptor of the changed property
        PropertyDescriptor propDesc = ((PropertyItem)e.OriginalSource).PropertyDescriptor;
        // try to get the RefreshPropertiesAttribute
        RefreshPropertiesAttribute attr
            = (RefreshPropertiesAttribute)propDesc.Attributes[typeof(RefreshPropertiesAttribute)];
        // if the attribute exists and it is set to All
        if (attr != null && attr.RefreshProperties == RefreshProperties.All)
        {
            // invoke PropertyGrid.UpdateContainerHelper
            System.Reflection.MethodInfo updateMethod
                = propertyGrid.GetType().GetMethod("UpdateContainerHelper", new Type[0]);
            updateMethod.Invoke(propertyGrid, new object[0]);
        }
    }
