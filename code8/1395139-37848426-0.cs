    List<ProcRecord> Records = new List<ProcRecord>();
    
    Records.Add(new ProcRecord("Ziggy"));
    Records.Add(new ProcRecord("Zalgo"));
    
    DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dgv1.Columns[0];
    col.DataSource = Enum.GetValues(typeof(SectionType));
    col.ValueType = typeof(SectionType);
    
    col = (DataGridViewComboBoxColumn)dgv1.Columns[4];
    col.DataSource = Enum.GetValues(typeof(RoleType));
    col.ValueType = typeof(RoleType);
