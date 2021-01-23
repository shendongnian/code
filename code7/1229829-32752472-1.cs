    if (property.PropertyType.IsEnum)
    {
       ComboBox cmb=new ComboBox();
       SetBindingForComboBoxWithEnumItems(cmb,
        =obj.GetType().GetProperty(property.Name).GetType());
       propertyPanel.Controls.Add(cmb);
    }
        
