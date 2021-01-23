    public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear (animated);
			SubscribeMessages ();
		}
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			UnSubscribeMessages ();
		}
		public void SubscribeMessages ()
		{
			_hideObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardNotification);
			_showObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardNotification);
		}
		public void UnSubscribeMessages ()
		{
			if (_hideObserver != null) NSNotificationCenter.DefaultCenter.RemoveObserver (_hideObserver);
			if (_showObserver != null) NSNotificationCenter.DefaultCenter.RemoveObserver(_showObserver);
		}
