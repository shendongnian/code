    private void MyToolTipController_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
    {
        var gridControl = e.SelectedControl as GridControl;
        if (gridControl != null)
        {
            var view = gridControl.FocusedView;
            //Your code here.
        }
    }
