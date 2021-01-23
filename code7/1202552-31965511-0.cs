    [Activity(Label = "App47", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        private static double calculationResult;
        private static bool calculationsDone;
        static MainActivity()
        {
            PerformCalculation().ContinueWith(t =>
            {
                calculationResult = t.Result;
                calculationsDone = true;
            }
            );
        }
        private static Task<double> PerformCalculation()
        {
            var tcs = new TaskCompletionSource<double>();
            tcs.SetResult(10.6);
            return tcs.Task;
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
