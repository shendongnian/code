    // This is your table with data in three columns
    DataTable events = new DataTable();
    // When the program starts
    public Form1()
    {
        InitializeComponent();
        // Add the columns to the table
        events.Columns.Add("ID", typeof(int));
        events.Columns.Add("Start Date", typeof(DateTime));
        events.Columns.Add("End Date", typeof(DateTime));
        // Set data and formats
        dataGridView1.DataSource = events;
        dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy"; // The way the date is shown
        dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy"; // Ex. 27-07-2016
    }
    // Add The row containing information about the event
    private void btnAdd_Click(object sender, EventArgs e)
    {
        // Weather or not the row should be added
        bool addRow = true;
        // Skip this if no rows are added yet
        foreach (DataRow row in events.Rows)
        {
            // Row id and dates
            int eventId = (int)row[0];
            DateTime rowStartDate = (DateTime)row[1];
            DateTime rowEndDate = (DateTime)row[2];
            // If new start date lies inside the timespan of an existing event
            bool newStartDateBetween = rowStartDate.Date <= dateTimePicker1.Value.Date && rowEndDate.Date >= dateTimePicker1.Value.Date;
            // If new end date lies inside the timespan of an existing event
            bool newEndDateBetween = rowStartDate.Date <= dateTimePicker2.Value.Date && rowEndDate.Date >= dateTimePicker2.Value.Date;
            // If any of these statements are true, show the error and dont add the new row
            if (eventId == numericUpDown1.Value || newStartDateBetween || newEndDateBetween || dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                if (eventId == numericUpDown1.Value)
                    MessageBox.Show("Event ID already taken!");
                if (newStartDateBetween)
                    MessageBox.Show("The starting date is within the timespan of event ID: " + row[0] + "!");
                if (newEndDateBetween)
                    MessageBox.Show("The ending date is within the timespan of event ID: " + row[0] + "!");
                if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
                    MessageBox.Show("The ending date is before the starting date!");
                // Dont add the row
                addRow = false;
                break;
            }
        }
        // Add the row if no errors
        if (addRow)
            events.Rows.Add((int)numericUpDown1.Value, dateTimePicker1.Value, dateTimePicker2.Value);
    }
