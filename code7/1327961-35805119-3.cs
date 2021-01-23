    using System.Runtime.InteropServices;
    ..
    public static class User32_DLL
    {
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
    }
