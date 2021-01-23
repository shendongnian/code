	private void ColorFlip(object sender, System.Timers.ElapsedEventArgs e)
	{
		RunOnUiThread (() => {
			var left = FindViewById<TextView> (Resource.Id.Left);
			var right = FindViewById<TextView> (Resource.Id.Right);
			if (IsRed) {
				left.SetBackgroundColor (Color.Black);
				right.SetBackgroundColor (Color.Blue);
				IsRed = false;
			} else {
				left.SetBackgroundColor (Color.Red);
				right.SetBackgroundColor (Color.Black);
				IsRed = true;
			}
		});
	}
