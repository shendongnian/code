    private static void HalfASecondCallback(object state)
    {
        Label l = state as Label; // in fact lblSystemStatus
        if (l != null)
        {
            UpdateLabel(l, Resources.DesktopClock_timerOneSecond_Tick_CPU__ + _cpu.GetCpuCounter().ToString() + @"%");
            TimerHalfASecond.Change(500, Timeout.Infinite);
        }
    }
