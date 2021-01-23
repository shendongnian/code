    private void btnCycle_Click(object sender, EventArgs e)
    {
        foreach (Employee emp in employees)
        {
            if (emp.Busy)
            {
                emp.ShiftsLeft--;
                emp.Busy = emp.ShiftsLeft > 0;
                // Do not try to update here
                // finish the logic loop and...
            }
        }
    }
    // Clear the content of both lists
    lstFree.Items.Clear();
    lstOccupied.Items.Clear();
    // Now rebuild both lists
    DisplayData(employees);
