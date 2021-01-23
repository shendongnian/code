    RepositoryItemCheckedComboBoxEdit ccb = new RepositoryItemCheckedComboBoxEdit();
    List<Student> data = new List<Student>();
    for(int i = 0; i < 3; i++)
    {
        data.Add(new Student() {Id=i, Name= $"Student {i}"});
    }
    ccb.EditValueType = EditValueTypeCollection.CSV; // It is default value
    ccb.DataSource = new BindingSource(data, null);
    ccb.ValueMember = "Id";
    ccb.DisplayMember = "Name";
    ccb.AllowMultiSelect = true;
    ccb.EditValueChanged += Ccb_EditValueChanged;
    //ccb.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton());
    //ccb.ButtonClick += Ccb_ButtonClick;
    //ccb.Popup += Ccb_Popup;
    gridView1.Columns["Name"].ColumnEdit = ccb;  // I have changed it from "ID" column to "Name" 
