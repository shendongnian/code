    	public override void WillAnimateRotation (UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillAnimateRotation (toInterfaceOrientation, duration);
			View.SetNeedsUpdateConstraints ();
		}
		public override void UpdateViewConstraints ()
		{
			base.UpdateViewConstraints ();
			var currentOrientation = InterfaceOrientation;
			//Update view constraints with current orientation
		}
