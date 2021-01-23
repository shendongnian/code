	protected override void OnResume()
	{
		base.OnResume();
		EditText txtFirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
		EditText txtEmailId = FindViewById<EditText>(Resource.Id.txtEmailId);
		EditText textPassword = FindViewById<EditText>(Resource.Id.txtPassword);
		EditText txtConfirmPassword = FindViewById<EditText>(Resource.Id.txtConfirmPassword);
		EventHandler<View.FocusChangeEventArgs> reFocusOnError = (object sender, View.FocusChangeEventArgs e) =>
		{
			if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
			{
				var editTextSender = sender as EditText;
				if (editTextSender.Id != Resource.Id.txtFirstName)
				{
					editTextSender.ClearFocus();
					txtFirstName.SetError("Non Empty Field", null);
					txtFirstName.RequestFocus();
					txtFirstName.Focusable = true;
					txtFirstName.ShowSoftInputOnFocus = true;
					InputMethodManager inputManager = (InputMethodManager)GetSystemService(Context.InputMethodService);
					inputManager.ShowSoftInput(txtFirstName, ShowFlags.Implicit);
				}
				    
			}
		};
		txtFirstName.FocusChange += reFocusOnError;
		txtEmailId.FocusChange += reFocusOnError;
		textPassword.FocusChange += reFocusOnError;
		txtConfirmPassword.FocusChange += reFocusOnError;
	}
