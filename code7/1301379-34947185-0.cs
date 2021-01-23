	public class SortKeepingDataGrid : DataGrid
	{
        // Dictionary to keep SortDescriptions per ItemSource
		private readonly Dictionary<object, List<SortDescription>> m_SortDescriptions =
			new Dictionary<object, List<SortDescription>>();
		protected override void OnSorting(DataGridSortingEventArgs eventArgs)
		{
			base.OnSorting(eventArgs);
			UpdateSorting();
		}
		protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
		{
			base.OnItemsSourceChanged(oldValue, newValue);
			ICollectionView view = CollectionViewSource.GetDefaultView(newValue);
			view.SortDescriptions.Clear();
            
            // reset SortDescriptions for new ItemSource
			if (m_SortDescriptions.ContainsKey(newValue))
				foreach (SortDescription sortDescription in m_SortDescriptions[newValue])
				{
					view.SortDescriptions.Add(sortDescription);
                    // I need to tell the column its SortDirection,
                    // otherwise it doesn't draw the triangle adornment
					DataGridColumn column = Columns.FirstOrDefault(c => c.SortMemberPath == sortDescription.PropertyName);
					if (column != null)
						column.SortDirection = sortDescription.Direction;
				}
		}
        // Store SortDescriptions in dictionary
		private void UpdateSorting()
		{		
			ICollectionView view = CollectionViewSource.GetDefaultView(ItemsSource);
			m_SortDescriptions[ItemsSource] = new List<SortDescription>(view.SortDescriptions);
		}
	}
