    foreach (ComboBoxItem cItem in departmentComboBox.ItemsSource){
    if (departmentComboBox.SelectedItem != null)
    {
        string selectedItemName = this.departmentComboBox.GetItemText(this.departmentComboBox.SelectedItem);
        criteria.Add(new Predicate<EmployeeModel>(x => x.Department.Equals(selectedItemName)));
        break;}
    }
    
