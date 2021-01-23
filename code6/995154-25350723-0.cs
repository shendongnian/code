    private void CheckSelectedItem()
    {
        // Get bound item object from datagrid
        object item = dgv_FrmSubjectClassRelation.CurrentRow.DataBoundItem;
        
        // Get corresponding index in listView
        Int32 itemIndexInCheckedListView = chkLstBxClass_FrmSubjecClassRelation.Items.IndexOf(item);
   
        // Check the item in listView
        chkLstBxClass_FrmSubjecClassRelation.SetItemCheckState(itemIndexInCheckedListView,
              CheckState.Checked);
    }
    private void dgv_FrmSubjectClassRelation_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        string classId = dgv_FrmSubjectClassRelation.CurrentRow.Cells[3].Value.ToString();
        string className = dgv_FrmSubjectClassRelation.CurrentRow.Cells[4].Value.ToString();
        foreach (int i in chkLstBxClass_FrmSubjecClassRelation.CheckedIndices)
        {
            //Here I am UnChecking Every Checked Item 
            chkLstBxClass_FrmSubjecClassRelation.SetItemCheckState(i, CheckState.Unchecked);
        }
 
        // --------------Check the selected item----------------
        this.CheckSelectedItem();
    }
