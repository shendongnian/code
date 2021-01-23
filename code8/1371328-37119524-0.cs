    public class CueBannerHelper
    {
        #region Win32 API's
        [StructLayout(LayoutKind.Sequential)]
        public struct COMBOBOXINFO
        {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public IntPtr stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndItem;
            public IntPtr hwndList;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    
            
        /// <summary>Used to get the current Cue Banner on an edit control.</summary>
        public const int EM_GETCUEBANNER = 0x1502;
        /// <summary>Used to set a Cue Banner on an edit control.</summary>
        public const int EM_SETCUEBANNER = 0x1501;
            
            
        [DllImport("user32.dll")]
        public static extern bool GetComboBoxInfo(IntPtr hwnd, ref COMBOBOXINFO pcbi);
    
        [DllImport("user32.dll")]
        public static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        #endregion
    
        #region Method members
        public static void SetCueBanner(Control control, string cueBanner) {
            if (control is ComboBox) {
                CueBannerHelper.COMBOBOXINFO info = new CueBannerHelper.COMBOBOXINFO();
                info.cbSize = Marshal.SizeOf(info);
    
                CueBannerHelper.GetComboBoxInfo(control.Handle, ref info);
    
                CueBannerHelper.SendMessage(info.hwndItem, CueBannerHelper.EM_SETCUEBANNER, 0, cueBanner);
            }
            else {
                CueBannerHelper.SendMessage(control.Handle, CueBannerHelper.EM_SETCUEBANNER, 0, cueBanner);
            }
        }
        #endregion
    }
