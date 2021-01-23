    public enum TooltipIcon
    {
        None,
        Info,
        Warning,
        Error
    }
    public class Balloon
    {
        private Control m_parent;
        private string m_text = "FMS Balloon Tooltip Control Display Message";
        private string m_title = "FMS Balloon Tooltip Message";
        private TooltipIcon m_titleIcon = TooltipIcon.None;
        private const int ECM_FIRST = 0x1500;
        private const int EM_SHOWBALLOONTIP = ECM_FIRST + 3;
        [DllImport("User32", SetLastError = true)]
        private static extern int SendMessage(
            IntPtr hWnd,
            int Msg,
            int wParam,
            IntPtr lParam);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct EDITBALLOONTIP
        {
            public int cbStruct;
            public string pszTitle;
            public string pszText;
            public int ttiIcon;
        }
        public Balloon()
        {
        }
        public Balloon(Control parent)
        {
            m_parent = parent;
        }
        public void Show()
        {
            EDITBALLOONTIP ebt = new EDITBALLOONTIP();
            ebt.cbStruct = Marshal.SizeOf(ebt);
            ebt.pszText = m_text;
            ebt.pszTitle = m_title;
            ebt.ttiIcon = (int)m_titleIcon;
            IntPtr ptrStruct = Marshal.AllocHGlobal(Marshal.SizeOf(ebt));
            Marshal.StructureToPtr(ebt, ptrStruct, false);
            System.Diagnostics.Debug.Assert(m_parent != null, "Parent control is null", "Set parent before calling Show");
            int ret = SendMessage(m_parent.Handle, EM_SHOWBALLOONTIP, 0, ptrStruct);
            Marshal.FreeHGlobal(ptrStruct);
        }
        public void Show(string text, Control parent, string title, TooltipIcon icon)
        {
        }
        public string Title
        {
            get
            {
                return m_title;
            }
            set
            {
                m_title = value;
            }
        }
        public TooltipIcon TitleIcon
        {
            get
            {
                return m_titleIcon;
            }
            set
            {
                m_titleIcon = value;
            }
        }
        public string Text
        {
            get
            {
                return m_text;
            }
            set
            {
                m_text = value;
            }
        }
        public Control Parent
        {
            get
            {
                return m_parent;
            }
            set
            {
                m_parent = value;
            }
        }
    }
