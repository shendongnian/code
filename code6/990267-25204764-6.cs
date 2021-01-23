    using System;
    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    namespace Example
    {
        [Activity(Label = "Example", MainLauncher = true, Icon = "@drawable/icon")]
        public class MainActivity : Activity
        {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                this.SetContentView(Resource.Layout.Main);
                this.FindViewById<Button>(Resource.Id.ForwardButton).Click += this.Forward;
            }
            public void Forward(object sender, EventArgs e)
            {
                this.SetContentView(Resource.Layout.Main2);
                this.FindViewById<Button>(Resource.Id.BackButton).Click += this.Back;
            }
            public void Back(object sender, EventArgs e)
            {
                this.SetContentView(Resource.Layout.Main);
                this.FindViewById<Button>(Resource.Id.ForwardButton).Click += this.Forward;
            }
        }
    }
