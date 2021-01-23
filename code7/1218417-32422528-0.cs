		private bool _isClosing;
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			_isClosing = true;
		}
		protected override void OnDeactivated(EventArgs e)
		{
			base.OnDeactivated(e);
			if (!_isClosing)
				Close();
		}
