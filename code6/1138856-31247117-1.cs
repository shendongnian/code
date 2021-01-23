    public class MainActivity : Activity
    {
        private RadioGroup _rg1;
        private RadioGroup _rg2;
        private Button _btn;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            _rg1 = FindViewById<RadioGroup>(Resource.Id.Radio1);
            _rg2 = FindViewById<RadioGroup>(Resource.Id.Radio2);
            _rg1.ClearCheck();
            _rg2.ClearCheck();
            _rg1.CheckedChange += OnRg1Change;
            _rg2.CheckedChange += OnRg2Change;
            _btn = FindViewById<Button>(Resource.Id.MyButton);
            _btn.Click += (sender, args) =>
            {
                var check1 = _rg1.CheckedRadioButtonId;
                var check2 = _rg2.CheckedRadioButtonId;
                var realCheck = check1 == -1
                    ? check2
                    : check1;
                Toast.MakeText(this, realCheck.ToString(), ToastLength.Long).Show();
            };
        }
        private void OnRg2Change(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            if (e.CheckedId == -1) return;
            _rg1.CheckedChange -= OnRg1Change;
            _rg1.ClearCheck();
            _rg1.CheckedChange += OnRg1Change;
        }
        private void OnRg1Change(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            if (e.CheckedId == -1) return;
            _rg2.CheckedChange -= OnRg2Change;
            _rg2.ClearCheck();
            _rg2.CheckedChange += OnRg2Change;
        }
    }
