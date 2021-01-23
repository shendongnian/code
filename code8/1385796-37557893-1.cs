    DataTable day = new DataTable();
    foreach (DataRow db in timeslots.Tables["schedules"].Rows)
    {
        string slot = ((DateTime)db["sdates"]).ToShortDateString();
        if (!comboBox2.Items.Contains(slot))
        {
            comboBox2.Items.Add(slot);
        }
    }
