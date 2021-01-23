	private void OnPreviewMouseButton(MouseButtonEventArgs e)
	{
		// We should only react to mouse buttons if we are in an auto close mode (where we have capture)
		if (_cacheValid[(int)CacheBits.CaptureEngaged] && !StaysOpen)
		{
			Debug.Assert( Mouse.Captured == _popupRoot.Value, "_cacheValid[(int)CacheBits.CaptureEngaged] == true but Mouse.Captured != _popupRoot");
			// If we got a mouse press/release and the mouse isn't on the popup (popup root), dismiss.
			// When captured to subtree, source will be the captured element for events outside the popup.
			if (_popupRoot.Value != null && e.OriginalSource == _popupRoot.Value)
			{
				// When we have capture we will get all mouse button up/down messages.
				// We should close if the press was outside.  The MouseButtonEventArgs don't tell whether we get this
				// message because we have capture or if it was legit, so we have to do a hit test.
				if (_popupRoot.Value.InputHitTest(e.GetPosition(_popupRoot.Value)) == null)
				{
					// The hit test didn't find any element; that means the click happened outside the popup.
					SetCurrentValueInternal(IsOpenProperty, BooleanBoxes.FalseBox);
				}
			}
		}
	}
