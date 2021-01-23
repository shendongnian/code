    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    
        SetContentView(Resource.Layout.NewsDetails);
    
        TextView Title = FindViewById<TextView>(Resource.Id.textTitle);
        TextView Source = FindViewById<TextView>(Resource.Id.textSource);
        WebView webDisplay = FindViewById<WebView>(Resource.Id.webDisplay);
        webDisplay.Settings.JavaScriptEnabled = true;
    
        string thisid=Intent.GetStringExtra ("id");
        string url = "http://MyApiUrl/";
        url = url + thisid;
    
        GetNewsAsync(url).ContinueWith(t=>
        {
            var result = t.Result;
    
            Title.Text = result.GetString("Title");
            Source.Text = result.GetString("Source");
            string ExternalReference = result.GetString("ExternalReference");
    
            webDisplay.LoadUrl(ExternalReference);
        });
      }
