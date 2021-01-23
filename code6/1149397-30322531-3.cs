		protected override void OnDeactivate(bool close)
		{
			if (close)
			{
				th.Abort();
			}
		}
