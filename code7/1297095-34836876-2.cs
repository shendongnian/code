     public class ColumnSelectingBehavior : Behavior<DataGrid>
    {
        public static readonly DependencyProperty TotalPresenterVisibilityProperty = DependencyProperty.Register(
            "TotalPresenterVisibility", typeof (Visibility), typeof (ColumnSelectingBehavior), new PropertyMetadata(Visibility.Collapsed));
        public Visibility TotalPresenterVisibility
        {
            get { return (Visibility) GetValue(TotalPresenterVisibilityProperty); }
            set { SetValue(TotalPresenterVisibilityProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Sorting += AssociatedObjectOnSorting;
        }
        private void AssociatedObjectOnSorting(object sender, DataGridSortingEventArgs dataGridSortingEventArgs)
        {
            var columnSortMemberPath = dataGridSortingEventArgs.Column.SortMemberPath;
            if(columnSortMemberPath != "Price")
                return;
            TotalPresenterVisibility = TotalPresenterVisibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Sorting -= AssociatedObjectOnSorting;
        }
    }
