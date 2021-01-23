    private EditText RegEmail;
    private Drawable _orginalDrawable;
    
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.Main);
    
        RegEmail = FindViewById<EditText>(Resource.Id.myEdt);
        _orginalDrawable = RegEmail.Background;
        RegEmail.TextChanged += (sender, e) =>
        {
            if (RegEmail.Text.Contains("@") && (RegEmail.Text.Contains(".")))
            {
                RegEmail.Background = _orginalDrawable;
            }
            else
            {
                RegEmail.SetBackgroundColor(Color.Red);
            }
        };
    }
