    int count = 1;
    TextView timerViewer;
    private System.Threading.Timer timer;
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.Main);
        timerViewer = FindViewById<TextView>(Resource.Id.textView1);
        timer = new Timer(x => UpdateView(), null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
    }
    private void UpdateView()
    {
        this.RunOnUiThread(() => timerViewer.Text = string.Format("{0} ticks!", count++));
    }
