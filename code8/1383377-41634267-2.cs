          private EditText datePickerText;
          private DatePickerDialogFragment dialog;
          protected override void OnCreate(Bundle savedInstanceState)
	    {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.report);
			
			var dp = new MvxDatePicker(this);
			dp.SpinnersShown = true;
			dp.DateTime = DateTime.Now;
			datePickerText.Focusable = false;
			datePickerText.Text = ViewModel.Date.ToString("dd-MMM-yyyy");
			datePickerText.Click += (sender, args) =>
			{
			if(datePickerText.Text == "")
	  dialog = new DatePickerDialogFragment(this, DateTime.Now,this);
		   else
	  dialog = new   DatePickerDialogFragment(this,Convert.ToDateTime(datePickerText.Text), this);
      dialog.Show(this.SupportFragmentManager, "date");
			};
			datePickerText.TextChanged += (sender, args) =>
			{
				ViewModel.Date = Convert.ToDateTime(datePickerText.Text);
			};
		}
      public void OnDateSet(DatePicker view, int year, int monthOfYear, int   dayOfMonth)
		{
			datePickerText.Text = new DateTime(year, monthOfYear + 1, dayOfMonth).ToString("dd-MMM-yyyy");
		}
