    private void bindingSource_ListChanged(object sender, ListChangedEventArgs e)
		{
			if (e.ListChangedType == ListChangedType.ItemChanged)
			{
				var entity = (IEntity)((BindingSource)sender).Current;
				if (entity.State == EntityState.Unchanged)
				{
					entity.State = EntityState.Modified;
				}
			}
		}
