       public static class ControlExtensions
        {
            /// Executes the Action asynchronously on the UI thread, does not block execution on the calling thread.
    
            public static void UIThread(this Control @this, Action code)
            {
                if (@this.InvokeRequired)
                {
                    @this.BeginInvoke(code);
                }
                else
                {
                    code.Invoke();
                }
            }
        } 
