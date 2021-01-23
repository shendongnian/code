    using System.Runtime.InteropServices;
    namespace FrmMarshalingInt
    {
        public class AnderSdk
        {
            // Declares a managed prototype for an array of integers by value.
            // The array size cannot be changed, but the array is copied back.
            [DllImport("AndorSDK.dll")]
            public static extern int GetOldestImage([In, Out] int[] array, ulong size);
        }
    }
