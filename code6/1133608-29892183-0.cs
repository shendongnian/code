    private void StrGridToolTipController_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
    {
        if (e.SelectedControl == gridViewST.GridControl)
        {
            var info = gridViewST.CalcHitInfo(e.ControlMousePosition);
    
            if (info.InRowCell && info.Column == gridViewST.VisibleColumns[1])
            {
                object value = gridViewST.GetRowCellValue(info.RowHandle, info.Column);
    
                //do the tooltip string of data 
            }
        }
    }
