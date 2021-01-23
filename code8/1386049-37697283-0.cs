		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			if (e.DeadCharProcessedKey == Key.Tab)
			{
				_ChangeFocus(e);
				e.Handled = true;
			}
			else
			{
				base.OnPreviewKeyDown(e);
			}
		}
		private static void _ChangeFocus(KeyEventArgs e)
		{
			var direction = Keyboard.Modifiers == ModifierKeys.Shift ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next;
			var focusedElement = Keyboard.FocusedElement as UIElement;
			if (focusedElement != null && focusedElement .MoveFocus(new TraversalRequest(direction)))
				e.Handled = true;
		}
