    static class ControlExtensions
    {
        public static IAsyncResult BeginInvoke(this Control c, Action a)
        {
            return c.BeginInvoke(a);
        }
    }
