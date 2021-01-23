    Theme = "@android:style/Theme.NoTitleBar" 
 .
    using Android.App;
    using Android.OS;
    using Android.Webkit;
    using Android.Views;  // Webkit required for WebView
    
    namespace LoadWebPage {
        [Activity(Label = "LoadWebPage", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")]
        public class Activity1 : Activity {
            protected override void OnCreate (Bundle bundle)
