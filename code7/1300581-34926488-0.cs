     gridView1.PopulateColumns();
     var checkEdit = gridView1.Columns["Value1"].RealColumnEdit as RepositoryItemCheckEdit;
     checkEdit.EditValueChanged += checkEdit_EditValueChanged;
     //...
    void checkEdit_EditValueChanged(object sender, EventArgs e) {
        gridView1.PostEditor();
    }
