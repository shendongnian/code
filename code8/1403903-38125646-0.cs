    public static class ExtensionOfControl
    {
        private const int WM_SETREDRAW = 11;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParmam);
        public static void SuspendDrawing(this Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }
        public static void ResumeDrawing(this Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
        public static void RunWithDrawingSuspended(this Control ctrl, Action code)
        {
            ctrl.SuspendDrawing();
            try
            {
                code();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ctrl.ResumeDrawing();
            }
        }
    }
