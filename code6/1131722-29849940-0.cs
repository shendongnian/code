    public class MainActivity : Activity
    {
        private int _count; 
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var button = FindViewById<Button>(Resource.Id.MyButton);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            
            button.Click += AddTab;
        }
        private void AddTab(object sender, EventArgs e)
        {
            _count += 1;
            var tab = ActionBar.NewTab();
            tab.SetTag("Tab" + _count);
            tab.SetText("tab - " + _count);
            var temp = _count;
            tab.TabSelected +=
                (o, args) => { Toast.MakeText(this, "Tab " + temp + " selected!", ToastLength.Long).Show(); };
            ActionBar.AddTab(tab);
        }
    }
