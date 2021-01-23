    <dxg:GridControl ItemsSource="{Binding ...">
        <dxg:GridControl.View>
            <dxg:TableView AllowEditing="False" 
                           MouseLeftButtonUp="TableView_MouseLeftButtonUp"/>
        </dxg:GridControl.View>
    </dxg:GridControl>
    void TableView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
        TableView tableView = sender as TableView;
        TableViewHitInfo hitInfo = tableView.CalcHitInfo(e.OriginalSource as DependencyObject);
        if (hitInfo.InRowCell) {
            object value = tableView.Grid.GetCellValue(hitInfo.RowHandle, hitInfo.Column);
            // do something
        }
    }
