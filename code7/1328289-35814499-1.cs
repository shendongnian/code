    public static bool hasWindowStyle(Process p)
    {
        IntPtr hnd = p.MainWindowHandle;
        UInt32 WS_DISABLED = 0x8000000;
        int GWL_STYLE = -16;
        bool visible = false;
        if (hnd != IntPtr.Zero)
        {
            UInt32 style = GetWindowLong(hnd, GWL_STYLE);
            visible = ((style & WS_DISABLED) != WS_DISABLED);
        }
        return visible;
    }
