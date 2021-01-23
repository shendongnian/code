    [Activity(Label = "Infusion Calculator")]
    public class infusionact : Activity
    {
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.Infusion);
        // Create your application here
        var volume = FindViewById<EditText>(Resource.Id.boxvolume);
        var drip = FindViewById<EditText>(Resource.Id.boxdrip);
        var dripmins = FindViewById<EditText>(Resource.Id.boxmins);
        
        Button button = FindViewById<Button>(Resource.Id.btncalculate);
        TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
        button.Click += delegate
        {
            // NEED TO FIGURE OUT HOW TO SET TXT LABEL WITH VAR ANSWERMINS ON CLICK  
           var answermins = volume.Text/(dripmins.Text*drip.Text);
                textView1.Text=answermins.ToString();
        };
    }
    }
