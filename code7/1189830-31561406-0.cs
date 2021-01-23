    DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
    editButton.HeaderText = "Update";
    editButton.Text = "Update";
    editButton.UseColumnTextForButtonValue = true;
    editButton.Width = 80;
    dbgViewObj.Columns.Add(editButton);//dbgViewObj is your datagridview control
    DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
    deleteButton.HeaderText = "Delete";
    deleteButton.Text = "Delete";
    deleteButton.UseColumnTextForButtonValue = true;
    deleteButton.Width = 80;
    dbgViewObj.Columns.Add(deleteButton);
