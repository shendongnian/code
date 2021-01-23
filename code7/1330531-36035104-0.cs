    using System.Threading.Tasks;
    using Microsoft.Win32;
    using System.Runtime.InteropServices;
    namespace screen_off
    {
         
        class NativeMethods
        {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
        private const int HWND_BROADCAST = 0xFFFF; //Level at which message broadcasts
        private const int SC_MONITORPOWER = 0xF170; //paramater that message is being passed to
        private const int WM_SYSCOMMAND = 0x112;
        internal int currentState; //tracks current state request
        internal int currentWait; //tracks current wait time delay
        public void sessionSwitch()
        {
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }
        public void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            SetMonitorInState(currentState, currentWait);
        }
        public void SetMonitorInState(int state, int delay)
        {
            Task.Delay(delay).ContinueWith(_ =>
            {
                SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, state);
                currentState = state;
                currentWait = delay;
            }
            );
        }
      }
    }
