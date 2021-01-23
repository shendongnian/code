    [Activity(Label = "App4", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
    
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
    
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
    
            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
    
            MyAdapter myAdapter = new MyAdapter(this, 0) ;
    
            myAdapter.RegisterDataSetObserver(new MyDataSetObserver());
        }
    }
    
    public class MyAdapter : ArrayAdapter
    {
        public MyAdapter(Context context, int layout) : base (context, layout)
        {
    
        }
    }
    
    public class MyDataSetObserver : DataSetObserver
    {
        public override void OnChanged()
        {
            base.OnChanged();
        }
    }
