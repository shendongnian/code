    public static class WindowsFormsControlExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            control.Invoke(action);
        }
    }
