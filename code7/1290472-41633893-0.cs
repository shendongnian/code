     private EditText  _txtdob;
     DatePickerDialog _datePickerDialog;
     protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.sign_up);
            _txtdob.Focusable = false;
            _txtdob.Click += (sender, e) =>
            {
                _datePickerDialog.Show();
            };
            _datePickerDialog = new DatePickerDialog(this, (sender, args) =>
            {
                _txtdob.Text = args.Date.ToString("dd/MM/yyyy");
                ViewModel.NewUser.DOB = args.Date.Date;
            }, 
            DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day);
    }
