    [Activity(
        Label = "test",
        MainLauncher = true,
        Icon = "@mipmap/icon",
        WindowSoftInputMode = SoftInput.StateHidden)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
    
            EditText edt = FindViewById<EditText>(Resource.Id.myEditText);
    
            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += delegate { edt.Text = edt.Text.Insert(edt.SelectionStart, "*"); };
        }
    }
