    public class ReadFileBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.RowDetailsVisibilityChanged += OnRowDetailsVisibilityChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.RowDetailsVisibilityChanged -= OnRowDetailsVisibilityChanged;
        }
        private void OnRowDetailsVisibilityChanged(object sender, DataGridRowDetailsEventArgs e)
        {
            var element = e.DetailsElement as TextBlock;
            element.Text = File.ReadAllLines((element.DataContext as DataLeakageScorer).Path);
        }
    }
