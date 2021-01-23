        private async void LoadDataAsync()
        {
            await Context.Employees.LoadAsync();
            await Context.Customers.LoadAsync();
            // The Invoke/Action Wrapper Keeps Modification of UI Elements from
            // complaining about what thread they are on.
            if (EmployeeDataGridView.InvokeRequired)
            {
                Action act = () => EmployeeBindingSource.DataSource = Context.Employees.Local.ToBindingList();
                EmployeeDataGridView.Invoke(act);
            }
            if (CustomerComboBox.InvokeRequired)
            {
                Action act = () =>
                {
                    CustomerBindingSource.DataSource = GetCustomerList();
                    CustomerComboBox.SelectedIndex = -1;
                };
                CustomerComboBox.Invoke(act);
            }
        }
