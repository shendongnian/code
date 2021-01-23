        #region DnD management
        private Book sourceBook;
        private void ListBoxItemPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            var listboxItem = sender as ListBoxItem;
            if (listboxItem == null)
                return;
            sourceBook = listboxItem.DataContext as Book;
            if (sourceBook == null)
                return;
            var data = new DataObject();
            data.SetData(sourceBook);
            // provide some data for DnD in other applications (Word, ...)
            data.SetData(DataFormats.StringFormat, sourceBook.ToString());
            DragDropEffects effect = DragDrop.DoDragDrop(listboxItem, data, DragDropEffects.Move | DragDropEffects.Copy);
        }
        private void ListBoxItemDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Book)))
                return;
            var listBoxItem = sender as ListBoxItem;
            if (listBoxItem == null)
                return;
            var targetBook = listBoxItem.DataContext as Book;
            if (targetBook != null)
            {
                viewModel.RecategorizeBook(sourceBook, targetBook.Category);
            }
            e.Handled = true;
        }
        private void ListBoxItemDragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine(e.Effects);
            if (!e.Data.GetDataPresent(typeof(Book)))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }
        private void GroupItemDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Book)))
                return;
            var groupItem = sender as GroupItem;
            if (groupItem == null)
                return;
            dynamic targetGroup = groupItem.DataContext;
            if (targetGroup != null)
            {
				// here I change the category of the book
				// and refresh the view of the collectionViewSource ( see link to project zipped further)
                viewModel.RecategorizeBook(sourceBook, targetGroup.Name as String);
            }
            e.Handled = true;
        }
        #endregion
