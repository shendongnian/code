    DataGridView dgview;
    
    DataGridViewComboBoxColumn districtColumn = new DataGridViewComboBoxColumn();
    
    districtColumn.DataSource = Districts; // Your collecton
    districtColumn.DisplayMember = "DistrictName";  // Just example, use appropriate one.
    districtColumn.ValueMember = "code";         // Just example, use appropriate one.
    
    dgview.Columns.Add(districtColumn);
