    private void scheduleBindingSource_AddingNew(object sender, AddingNewEventArgs e)
    {
        _scheduleAdding = true;
    }
    private void scheduleBindingSource_CurrentChanged(object sender, EventArgs e)
    {
        if (_scheduleAdding)
        {
            Schedule s = (Schedule)scheduleBindingSource.Current;
            s.EmployeeName = employeeComboBox.Text;
            s.From = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1);
            _context.Schedules.Add(s);
            _scheduleAdding = false;
        }
    }
