    List<ProcRecord> Records = new List<ProcRecord>();
    
    // add some records
    Records.Add(new ProcRecord()
    {
        Author = "Ziggy",
        PageSection = SectionType.ESJP_SECTION_BODY,
        UserRole = RoleType.ESJP_ROLE_FEATURE_LEAD
    });
    Records.Add(new ProcRecord()
    {
        Author = "Zalgo",
        PageSection = SectionType.ESJP_SECTION_BODY,
        UserRole = RoleType.ESJP_ROLE_FEATURE_LEAD
    });
    
    // set cbo datasources
    DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dgv1.Columns[0];
    col.DataSource = Enum.GetValues(typeof(SectionType));
    col.ValueType = typeof(SectionType);
    
    col = (DataGridViewComboBoxColumn)dgv1.Columns[4];
    col.DataSource = Enum.GetValues(typeof(RoleType));
    col.ValueType = typeof(RoleType);
