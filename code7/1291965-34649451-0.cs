    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        [MarshalAs(UnmanagedType.U2)]
        public short Year;
        [MarshalAs(UnmanagedType.U2)]
        public short Month;
        [MarshalAs(UnmanagedType.U2)]
        public short DayOfWeek;
        [MarshalAs(UnmanagedType.U2)]
        public short Day;
        [MarshalAs(UnmanagedType.U2)]
        public short Hour;
        [MarshalAs(UnmanagedType.U2)]
        public short Minute;
        [MarshalAs(UnmanagedType.U2)]
        public short Second;
        [MarshalAs(UnmanagedType.U2)]
        public short Milliseconds;
    }
    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetSystemTime(
    [In] ref SystemTime lpSystemTime);
    /// <summary>
    /// Set the system time to the given date/time. 
    /// The time must be given in utc.
    /// </summary>
    /// <param name="dt">Date/time to set the system clock to</param>
    /// <returns>True on success, false on failure. This fails if the current user has insufficient rights to set the system clock. </returns>
    /// <remarks>This method needs administrative priviledges to succeed.</remarks>
    public static bool SetSystemTimeUtc(DateTime dt)
    {
        bool bSuccess = false;
        if (dt.Year >= 2100) // limit the year to prevent older C-routines to crash on the local time
        {
            dt = new DateTime(2099, dt.Month, dt.Day);
        }
        SystemTime st = DateTimeToSystemTime(dt);
        try
        {
            bSuccess = SetSystemTime(ref st);
        }
        catch (System.UnauthorizedAccessException)
        {
            bSuccess = false;
        }
        catch (System.Security.SecurityException)
        {
            bSuccess = false;
        }
        return bSuccess;
    }
    private static SystemTime DateTimeToSystemTime(DateTime dt)
    {
        SystemTime st;
        st.Year = (short)dt.Year;
        st.Day = (short)dt.Day;
        st.Month = (short)dt.Month;
        st.Hour = (short)dt.Hour;
        st.Minute = (short)dt.Minute;
        st.Second = (short)dt.Second;
        st.Milliseconds = (short)dt.Millisecond;
        st.DayOfWeek = (short)dt.DayOfWeek;
        return st;
    }
