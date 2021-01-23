    public class ReACTDataGrid : DataGrid
    {
        private bool templateApplied;
        protected override void OnApplyTemplate()
        {
            templateApplied = true;
            base.OnApplyTemplate();
            CheckIfItemsEmptyAndUpdateVisualState();
        }
        
        protected override void OnLoadingRow(DataGridRowEventArgs e)
        {
            if (templateApplied) CheckIfItemsEmptyAndUpdateVisualState();
        }
        
        protected override void OnUnloadingRow(DataGridRowEventArgs e)
        {
            if (templateApplied) CheckIfItemsEmptyAndUpdateVisualState();
        }
        
        private void CheckIfItemsEmptyAndUpdateVisualState()
        {
            if (this.ItemsSource.IsNullOrEmpty())
                VisualStateManager.GoToState(this, "HasNoItems", false);
            else
                VisualStateManager.GoToState(this, "HasItems", false);
        }
    }
