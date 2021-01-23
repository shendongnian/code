    public static class SubAsstToolTip
    {
        private static SubAsstToolTipWindow ttip = new SubAsstToolTipWindow();
        public delegate void ToolTipShowEventHandler();
        public static event ToolTipShowEventHandler ToolTipShow;
        public static void Show()
        {
            // This is a static boolean that I set here but is accessible from the form.
            Vars.MyToolTipIsOn = true; 
            if (ToolTipShow != null)
            {
                ToolTipShow();
            }
        }
        public static void Hide()
        {
            // This is a static boolean that I set here but is accessible from the form.
            Vars.MyToolTipIsOn = false;
            if (ToolTipShow != null)
            {
                ToolTipShow();
            }
        }
    }
