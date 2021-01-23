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
            }
            [Java.Interop.Export("OnClick")]
            public void OnClick (View view)
            {
                var button = (Button)view;
                if (button.Id == Resource.Id.ForwardButton) {
                    this.SetContentView(Resource.Layout.Main2);
                } else if (button.Id == Resource.Id.BackButton) {
                    this.SetContentView(Resource.Layout.Main);
                }
            }
        }
    }
