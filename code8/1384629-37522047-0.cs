        protected IDictionary<DataGridColumn, ContextMenu> _CachedContextMenues = new Dictionary<DataGridColumn, ContextMenu>();
	protected void ToggleColumnVisibilityCmdExecute(DataGridColumn column)
        {
            bool isVisible = (column.Visibility == Visibility.Visible);
            Visibility newVisibility = (isVisible) ? Visibility.Hidden : Visibility.Visible;
            
            if(newVisibility != Visibility.Visible)
            {
                // We're hiding the column, so we'll cache its context menu so for re-use once the column
                // becomes visible again
                var contextMenu = _AssociatedObject.SafeFindDescendants<DataGridColumnHeader>(z => z.Column == column).Single().ContextMenu;
                _CachedContextMenues.Add(column, contextMenu);
            }
            if(newVisibility == Visibility.Visible)
            {
                // The column just turned visible again, so we set its context menu to the
                // previously cached one
                Observable
                    .FromEventPattern(_AssociatedObject, "LayoutUpdated")
                    .Take(1)
                    .Select(x => _AssociatedObject.SafeFindDescendants<DataGridColumnHeader>(z => z.Column == column).Single())
                    .Subscribe(x =>
                        {
                            var c = x.Column;
                            var cachedMenu = _CachedContextMenues[c];
                            _CachedContextMenues.Remove(c);
                            x.ContextMenu = cachedMenu;
                        });
            }
            column.Visibility = newVisibility;
        }
