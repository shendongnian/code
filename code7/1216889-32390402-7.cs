	public class GridSizeBehavior : Behavior<Grid>
	{
		public int Columns
		{
			get { return (int)GetValue(ColumnsProperty); }
			set { SetValue(ColumnsProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Columns.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ColumnsProperty =
			DependencyProperty.Register("Columns", typeof(int), typeof(GridSizeBehavior), new PropertyMetadata(0, OnColumnsChanged));
		static void OnColumnsChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
		{
			var behaviour = depObj as GridSizeBehavior;
			if (behaviour == null)
				return;
			behaviour.SetColumns();
		}
		private void SetColumns()
		{
			var grid = this.AssociatedObject;
			if (grid == null)
				return;
			int columns = this.Columns;
			grid.ColumnDefinitions.Clear();
			for (int i = 0; i < columns; i++)
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
		}
		public int Rows
		{
			get { return (int)GetValue(RowsProperty); }
			set { SetValue(RowsProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Rows.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty RowsProperty =
			DependencyProperty.Register("Rows", typeof(int), typeof(GridSizeBehavior), new PropertyMetadata(0, OnRowsChanged));
		static void OnRowsChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
		{
			var behaviour = depObj as GridSizeBehavior;
			if (behaviour == null)
				return;
			behaviour.SetRows();
		}
		private void SetRows()
		{
			var grid = this.AssociatedObject;
			if (grid == null)
				return;
			int Rows = this.Rows;
			grid.RowDefinitions.Clear();
			for (int i = 0; i < Rows; i++)
				grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
		}
		protected override void OnAttached()
		{
			base.OnAttached();
			SetColumns();
			SetRows();
		}
	}
