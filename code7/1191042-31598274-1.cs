    protected override void OnCreate (Bundle bundle)
            {
            SetContentView (Resource.Layout.next1);
            TextView textvtest = (TextView) FindViewById(Resource.Id.textView1);
            
            string text = Intent.GetStringExtra ("MyData") ?? "Data not available";
            textvtest.Text = text;
            
            }
