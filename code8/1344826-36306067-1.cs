    foreach (ComboBoxItem cItem in departmentComboBox.ItemsSource)
    {
        if (departmentComboBox.SelectedItem != null)
        {
            criteria.Add(new Predicate<EmployeeModel>(x => x.Department == "" + departmentComboBox.SelectedItem));
            break;
        }
    }
