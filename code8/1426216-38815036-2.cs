    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Interop;
    /// Provides NetFX 4.0 EnsureHandle method for
    /// NetFX 3.5 WindowInteropHelper class.
    public static class WindowInteropHelperExtensions {
        public static IntPtr EnsureHandle(this WindowInteropHelper helper) {
            if (helper == null) throw new ArgumentNullException("helper");
            if (helper.Handle != IntPtr.Zero) return helper.Handle;
            var window = (Window) typeof(WindowInteropHelper).InvokeMember("_window",
                BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic,
                null, helper, null);
            typeof(Window).InvokeMember("SafeCreateWindow",
                BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic,
                null, window, null);
            return helper.Handle;
        }
    }
