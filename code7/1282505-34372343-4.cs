    private void btnCycle_Click(object sender, EventArgs e)
    {
        // Clear the content of both lists
        lstFree.Items.Clear();
        lstOccupied.Items.Clear();
    
        foreach (Employee emp in employees)
        {
            if (emp.Busy)
            {
                emp.ShiftsLeft--;
                if (emp.ShiftsLeft == 0)
                {
                    lstFree.Items.Add(emp);
                    emp.Busy = false;
                }
                else
                    lstOccupied.Items.Add(emp);
            }
        }
    }
