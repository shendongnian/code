        protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			_addressManual = FindViewById<EditText>(Resource.Id.addressManual);
		}
		protected override void OnResume()
		{
			_addressHomeManualToogle.CheckedChange += _addressHomeManualToogle_CheckedChange;
			base.OnResume();
		}
		protected override void OnPause()
		{
			_addressHomeManualToogle.Click -= _addressHomeManualToogle_CheckedChange;
			base.OnPause();
		}
		void _addressHomeManualToogle_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			if (e.IsChecked)
				_addressManual.Visibility = Android.Views.ViewStates.Visible;
			else
				_addressManual.Visibility = Android.Views.ViewStates.Gone;
		}
