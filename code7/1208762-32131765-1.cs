        /// <summary>
        /// Window Hook ID 14 - Low level mouse proc.
        /// </summary>
        internal const int WH_MOUSE_LL = 14;
        /// <summary>
        /// Get the window handle from a specified point.
        /// </summary>
        /// <param name="point">Specified point</param>
        /// <returns>Window handle</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr WindowFromPoint(CPoint point);
        /// <summary>
        /// Register a hook.
        /// </summary>
        /// <param name="idHook">Hook type</param>
        /// <param name="lpfn">Function pointer</param>
        /// <param name="hMod">Module ID</param>
        /// <param name="dwThreadId">Thread ID</param>
        /// <returns>Hook handle</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
        /// <summary>
        /// Unregister a hook.
        /// </summary>
        /// <param name="hhk">Hook handle</param>
        /// <returns>Successful</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);
        /// <summary>
        /// Call next hook (if needed).
        /// </summary>
        /// <param name="hhk">Hook handle</param>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// Get moudle handle by module name.
        /// </summary>
        /// <param name="lpModuleName">Module name</param>
        /// <returns>Module handle</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);
        /// <summary>
        /// Get current cursor position.
        /// </summary>
        /// <param name="lpPoint">Output position</param>
        /// <returns>Successful</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(out CPoint lpPoint);
