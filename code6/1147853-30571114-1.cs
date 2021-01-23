    [assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
    namespace JetAdvice_Free.Droid.Services
    {
       public class AndroidMethods : IAndroidMethods
       {
           public void CloseApp()
           {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
           }
       }
    }
