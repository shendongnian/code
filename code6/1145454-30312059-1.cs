        public static bool MoveUpCursor = false;
		public static bool DragDroppingOn = false;
		private void ObjectDraggingFrom_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			if (MoveUpCursor)
			{
				e.UseDefaultCursors = false;
				Mouse.SetCursor(Cursors.UpArrow);
			}
			else
			{
				e.UseDefaultCursors = true;
			}
			e.Handled = true;
		}
    		private void ObjectDragging_Drop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				((DataExploreViewModel)DataContext).ImportDraggedAndDroppedFiles((string[])e.Data.GetData(DataFormats.FileDrop));
			}
			DragDroppingOn = false;
		}
    		private void ObjectDraggingFrom_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				if (myData.SelectedItem == null)
				{
					return;
				}
					var mousePos = e.GetPosition(null);
					var diff = _startPoint - mousePos;
					if (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance
						|| Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
					{
						DragDroppingOn = true;
						DragDrop.DoDragDrop(FileTree, data, DragDropEffects.Move | DragDropEffects.Copy);
					}
				}
		}
