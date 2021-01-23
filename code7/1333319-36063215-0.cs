	private void DoAnimation()
	{
		_timer = new System.Timers.Timer();
		//Trigger event every second
		_timer.Interval = 1000;
		_timer.Elapsed += CheckStatus;
		//count down 5 seconds
		_countSeconds = 5000;
		_timer.Enabled = true;
		
	}
	private void SpinAnimation()
	{
	switch (_letterShowState) {
	case SomeStateStates.State1:
		_pic1.IsVisible = false;
		_pic2.IsVisible = true;
		_pic3.IsVisible = false;
		_letterShowState = SomeStateStates.State2;
		break;
		}
		}
	private void CheckStatus(object sender, System.Timers.ElapsedEventArgs e) {
		_countSeconds--;
		new System.Threading.Thread(new System.Threading.ThreadStart(() => {
			Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
				SpinAnimation();
			});
		})).Start();
		if (_countSeconds == 0)
		{
			_timer.Stop();
		}
	}
