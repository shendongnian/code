    IList<HistoryItem> history = _currentCustomer.HistoryItems;
    dgvCustomerHistory.AutoGenerateColumns = false;
 
    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
    column.HeaderText = "Communication Type";
    column.DataPropertyName = "TypeOfCommunication"; // Name of property
    dgvCustomerHistory.Columns.Add(column);
    dgvCustomerHistory.DataSource = history;  
