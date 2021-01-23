      protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                SetContentView(Resource.Layout.Main);
    
                Button OK = FindViewById<Button>(Resource.Id.btnOK);
                Button Cancel = FindViewById<Button>(Resource.Id.btnCancel);
                TimePicker picker = FindViewById<TimePicker>(Resource.Id.picker);
                TextView txt = FindViewById<TextView>(Resource.Id.txt);
    
                OK.Click += (sender, e) => 
                    {
                        //getting values from TImePicker via CurrentHour/CurrentMinutes
                        txt.Text = String.Format("{0} : {1}",picker.CurrentHour,picker.CurrentMinute);
                    };
              
            }
