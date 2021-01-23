    ProgressBar pb;
    Button translateButton;
    EditText phoneNumberText;
    
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.Main);
    
        translateButton = FindViewById<Button>(Resource.Id.translateButton);
        phoneNumberText = FindViewById<EditText>(Resource.Id.phoneNumberText);
        pb = FindViewById<ProgressBar>(Resource.Id.pb);
        pb.Visibility = ViewStates.Invisible;
    
        translateButton.Click += translateButtonClicked;
    }
    
    async void translateButtonClicked (object sender, EventArgs e)
    {
        pb.Visibility = ViewStates.Visible;
        await myMethod();
        pb.Visibility = ViewStates.Gone;
    }
    
    async Task myMethod()
    {
        await Task.Run(() => {
            //
            // Do the work stuff here
            //
        });
    }
