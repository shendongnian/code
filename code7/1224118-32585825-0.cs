    private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e) 
    {
        if (e.Column != treeList1.Columns["Check"])
            return;
    
        string caption = "Node ID: " + e.Node.Id.ToString();
        DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo viewInfo = (e.EditViewInfo as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo);
    
        DevExpress.Utils.Drawing.CheckObjectInfoArgs checkInfo = viewInfo.CheckInfo;
    
        checkInfo.Caption = caption;
        checkInfo.Graphics = e.Graphics;
        viewInfo.CheckPainter.CalcObjectBounds(checkInfo);
    }
