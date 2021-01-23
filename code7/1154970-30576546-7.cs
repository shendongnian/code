    public class ExpandDetailsOfNewRowsBehavior : Behavior<RadGridView>
	{
		protected override void OnAttached()
		{
			base.OnAttached();
			INotifyCollectionChanged items = AssociatedObject.Items;
			items.CollectionChanged += OnItemsChanged;
            AssociatedObject.RowLoaded += CheckLoadedRowIfShouldExpand;
		}
        private void CheckLoadedRowIfShouldExpand()
        {
            foreach(var item in m_shouldBeExpanded )
            {
                GridViewRow row = AssociatedObject.GetRowForItem( item );
                if ( row != null )
                {
                      row.DetailsVisibility = Visibility.Visible;
                       m_shouldBeExpanded.Remove(item);
                }
            }
        }
        private List<object> m_shouldBeExpanded = new List<object>();
		private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			if (eventArgs.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in eventArgs.NewItems)
			    {
				  GridViewRow row = AssociatedObject.GetRowForItem( item );
                  if ( row == null )
                  {
                    // row is not loaded yet
                    m_shouldBeExpanded.Add(item);
                  }
                  else
                  {
                    row.DetailsVisibility = Visibility.Visible;
		    		// see http://docs.telerik.com/devtools/silverlight/
                    //                  controls/radgridview/row-details/programming
				    // "To manually change the visibility of a row - set its
                    // DetailsVisibility property to either Visibility.Collapsed
                    // or Visibility.Visible"
                  }
                }
			}
		}
		protected override void OnDetaching()
		{
			INotifyCollectionChanged items = AssociatedObject.Items;
			items.CollectionChanged -= OnItemsChanged;
            AssociatedObject.RowLoaded -= CheckLoadedRowIfShouldExpand;
			base.OnDetaching();
		}
	}
