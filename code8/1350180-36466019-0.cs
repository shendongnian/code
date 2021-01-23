    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
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
            Button searchButton = FindViewById<Button>(Resource.Id.searchButton);
            searchButton.Click += SearchButton_Click;
            EditText artistNameEditText = FindViewById<EditText>(Resource.Id.artistNameEditText);
            artistNameEditText.TextChanged += artistNameEditText_TextChanged;
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = "Search Button Clicked!";
            // Now it is working! :)
        }
        private void artistNameEditText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Toast.MakeText(this, "Text has just changed!", ToastLength.Long).Show();
            // Now it is working! :)
        }
    }
