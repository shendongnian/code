    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Forms;
    public static class NotifyIconRect
    {
        #region Win32
        [DllImport("Shell32.dll", SetLastError = true)]
        private static extern int Shell_NotifyIconGetRect(
            [In] ref NOTIFYICONIDENTIFIER identifier,
            out RECT iconLocation);
        [StructLayout(LayoutKind.Sequential)]
        private struct NOTIFYICONIDENTIFIER
        {
            public uint cbSize;
            public IntPtr hWnd;
            public uint uID;
            public GUID guidItem; // System.Guid can be used.
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct GUID
        {
            public uint Data1;
            public ushort Data2;
            public ushort Data3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Data4;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public static implicit operator Rect(RECT rect)
            {
                if ((rect.right - rect.left < 0) || (rect.bottom - rect.top < 0))
                    return Rect.Empty;
                return new Rect(
                    rect.left,
                    rect.top,
                    rect.right - rect.left,
                    rect.bottom - rect.top);
            }
        }
        
        #endregion
        
        public static Rect GetNotifyIconRect(NotifyIcon notifyIcon)
        {
            NOTIFYICONIDENTIFIER identifier;
            if (!TryGetNotifyIconIdentifier(notifyIcon, out identifier))
                return Rect.Empty;
            RECT iconLocation;
            int result = Shell_NotifyIconGetRect(ref identifier, out iconLocation);
            
            switch (result)
            {
                case 0: // 0 means S_OK.
                case 1: // 1 means S_FALSE.
                    return iconLocation;
                default:
                    return Rect.Empty;
            }
        }
        private static bool TryGetNotifyIconIdentifier(NotifyIcon notifyIcon, out NOTIFYICONIDENTIFIER identifier)
        {
            identifier = new NOTIFYICONIDENTIFIER { cbSize = (uint)Marshal.SizeOf(typeof(NOTIFYICONIDENTIFIER))    };
            int id;
            if (!TryGetFieldValue(notifyIcon, "id", out id))
                return false;
            NativeWindow window;
            if (!TryGetFieldValue(notifyIcon, "window", out window))
                return false;
            identifier.uID = (uint)id;
            identifier.hWnd = window.Handle;
            return true;
        }
        private static bool TryGetFieldValue<T>(object instance, string fieldName, out T fieldValue)
        {
            fieldValue = default(T);
            var fieldInfo = instance.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo == null)
                return false;
            var value = fieldInfo.GetValue(instance);
            if (!(value is T))
                return false;
            fieldValue = (T)value;
            return true;
        }
    }
