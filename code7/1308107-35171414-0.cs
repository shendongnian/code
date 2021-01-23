    gridControl1.DataSource = Repository.GetOrders();
    // Some Visual Options for details
    gridView1.LevelIndent = 0;
    gridView1.OptionsDetail.ShowDetailTabs = false;
    gridView1.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
    // 
    gridControl1.Paint += gridControl1_Paint;
    //...
    void gridControl1_Paint(object sender, PaintEventArgs e) {
        var viewInfo = gridView1.GetViewInfo() as GridViewInfo;
        foreach(var rowInfo in viewInfo.RowsInfo) {
            if(gridView1.GetMasterRowExpanded(rowInfo.RowHandle))
                e.Graphics.DrawRectangle(Pens.Blue, rowInfo.TotalBounds);
        }
    }
