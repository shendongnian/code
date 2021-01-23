    if (property.PropertyType.IsEnum)
    {
       ComboBox cmb=new ComboBox();
       Binding myBinding = new Binding();
       myBinding.Path = new PropertyPath(property.Name);
       myBinding.Mode = BindingMode.TwoWay;
       myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
       BindingOperations.SetBinding(cmb, ComboBox.SelectedValueProperty, myBinding);
       SetBindingForComboBoxWithEnumItems(cmb,obj.GetType().GetProperty(property.Name).GetType());
       propertyPanel.Controls.Add(cmb);
    }
            
