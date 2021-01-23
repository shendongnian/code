    [assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
    namespace Your.Namespace
    {
       public class AndroidMethods : IAndroidMethods
       {
           public void CloseApp()
           {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
           }
       }
    }
