    public class DialogClicker
    {
        private delegate bool EnumWindowsProc(int hWnd, int lParam);
        private const int BM_SETSTATE = 0x00F3;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc callbackFunc, int lParam);
        [DllImport("user32.dll")]
        private static extern int EnumChildWindows(int hWnd, EnumWindowsProc callbackFunc, int lParam);
        [DllImport("user32.dll")]
        private static extern int GetWindowText(int hWnd, StringBuilder buff, int maxCount);
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        private const int MsgBufferSize = 256;
        private bool _textFound;
        private int _btnhWnd;
        private readonly Timer _timer;
        public string TargetHeader { get; private set; }
        public string ButtonText { get; private set; }
        public string SearchText { get; private set; }
        public int TimerInterval { get; private set; }
        public DialogClicker(string header, string button, string search, int interval)
        {
            TargetHeader = header;
            ButtonText = button;
            SearchText = search;
            TimerInterval = interval;
            _timer = new Timer(interval);
            _timer.Elapsed += ElapsedHandler;            
        }
        public void Toggle(bool active)
        {
            _timer.Enabled = active;
        }
        private void ElapsedHandler(object sender, ElapsedEventArgs e)
        {
            _btnhWnd = 0;
            _textFound = string.IsNullOrEmpty(SearchText);
            EnumWindows(EnumProc, 0);
        }
        private bool EnumProc(int hWnd, int lParam)
        {
            var heading = new StringBuilder(MsgBufferSize);
            GetWindowText(hWnd, heading, MsgBufferSize);
            var title = heading.ToString();
            if (string.IsNullOrEmpty(title) || !title.Equals(TargetHeader)) return true;
            EnumChildWindows(hWnd, EnumChildProc, 0);
            return false;
        }
        private bool EnumChildProc(int hWnd, int lParam)
        {
            var title = new StringBuilder(MsgBufferSize);
            GetWindowText(hWnd, title, MsgBufferSize);
            var text = title.ToString();
            if (string.IsNullOrEmpty(text)) return true;
            if (!_textFound) _textFound = text.Contains(SearchText);
            if (text.Equals(ButtonText)) _btnhWnd = hWnd;
            if (_btnhWnd <= 0 || !_textFound) return true;
            SendMessage(_btnhWnd, BM_SETSTATE, 1, 0);
            SendMessage(_btnhWnd, WM_LBUTTONDOWN, 0, 0);
            SendMessage(_btnhWnd, WM_LBUTTONUP, 0, 0);
            SendMessage(_btnhWnd, BM_SETSTATE, 1, 0);
            return false;
        }
    }
