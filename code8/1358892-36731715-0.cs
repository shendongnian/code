    private void sreachbtn_Click(object sender, EventArgs e)
    {
        int searchID = int.Parse(txtIdSearch.Text);
        // Need to handle if the user input is not a number..
        Employee[] employeeResults = employee.Where(e => e.employeeID == searchID).ToArray();
        // For possibility that your ID is not unique..
        // code to display results
        for (int i = 0; i < employeeResults .Length; i++)
        {
            string employeeString = employeeResults [i].employeeInformationToString() + "\r\n";
    
            listBox1.Items.Add(employeeString);
    
        }
     }
