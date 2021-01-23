    public class ExpandDetailsOfNewRowsBehavior : Behavior<RadGridView>
	{
		protected override void OnAttached()
		{
			base.OnAttached();
			INotifyCollectionChanged items = AssociatedObject.Items;
			items.CollectionChanged += OnItemsChanged;
		}
		private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			if (eventArgs.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in eventArgs.NewItems)
			    {
				    GridViewRow row = AssociatedObject.GetRowForItem( item );
       				row.DetailsVisibility = Visibility.Visible;
		    		// see http://docs.telerik.com/devtools/silverlight/
                    //                  controls/radgridview/row-details/programming
				    // "To manually change the visibility of a row - set its
                    // DetailsVisibility property to either Visibility.Collapsed
                    // or Visibility.Visible"
                }
			}
		}
		protected override void OnDetaching()
		{
			INotifyCollectionChanged items = AssociatedObject.Items;
			items.CollectionChanged -= OnItemsChanged;
			base.OnDetaching();
		}
	}
