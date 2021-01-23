    private void btnSearch_Click(object sender, EventArgs e)
    {
        pnlRead.BringToFront();
        listRead.Items.Clear();
        try
        {
            string[] EmployeeData = File.ReadAllLines("Employee.txt");
            if(EmployeeData.Contains(txtSearch.Text))
                listRead.Items.AddRange(EmployeeData);
        }
        catch
        {
            MessageBox.Show("File or path not found or invalid.");
        } 
    }
