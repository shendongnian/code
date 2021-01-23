    using Android.Telephony;
    
    public class MyActivity : Activity
    {
        private string GetMyPhoneNumber() 
        { 
            var tMgr = (TelephonyManager)GetSystemService(TelephonyService);
            return tMgr.Line1Number; 
        }
    }
