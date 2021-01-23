    if(e.SelectedControl == gridControl1) {
       GridView view = gridControl1.FocusedView as GridView;
       GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
       if(info.InRowCell) {
          string text = "Text - " +     view.GetRowCellDisplayText(info.RowHandle, info.Column);
          string cellKey = info.RowHandle.ToString() + " - " + info.Column.ToString();
          e.Info = new DevExpress.Utils.ToolTipControlInfo(cellKey, text);
         // this area it's where you have to put your full text
       }
    }
