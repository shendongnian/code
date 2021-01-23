    private void treeList1_ShownEditor(object sender, System.EventArgs e) 
    {
        DevExpress.XtraTreeList.TreeList tl = sender as DevExpress.XtraTreeList.TreeList;
    
        if (tl.FocusedColumn != tl.Columns["Check"])
            return;
    
        (tl.ActiveEditor as DevExpress.XtraEditors.CheckEdit).Properties.Caption = "Node ID: " + tl.FocusedNode.Id.ToString();
    }
