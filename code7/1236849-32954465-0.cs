    using System.Diagnostics;
    using System.Runtime.InteropServices;
    public static class Module1
    {
        [DllImport("autodetect.dll")]
        public static extern int autodetect_SearchAxis(bool onusb, byte searchsubadress, ref string portname, ref string devicelocation);
        public static string AxisCom;
        public static byte AxisAddress = 1;
        public static string Dummy;
        public static int rc;
        public static void Main()
        {
            Dummy = new string(' ', 1024);
            AxisCom = new string(' ', 1024);
            rc = autodetect_SearchAxis(false, AxisAddress, ref Dummy, ref AxisCom);
            Debug.WriteLine("rc: " + rc.ToString());
            Debug.WriteLine("AxisCom: " + AxisCom.ToString());
        }
    }
