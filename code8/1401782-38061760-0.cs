    public delegate int BrowseCallbackProc(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr lParam);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    [ComVisible(true)]
    public class BROWSEINFO
    {
        public IntPtr hwndOwner;
        public IntPtr pidlRoot;
        public IntPtr pszDisplayName;
        public string lpszTitle;
        public int ulFlags;
        public BrowseCallbackProc lpfn;
        public IntPtr lParam;
        public int iImage;
    }
    public class Win32SDK
    {
        [DllImport("shell32.dll", PreserveSig = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SHBrowseForFolder(BROWSEINFO bi);
        [DllImport("shell32.dll", PreserveSig = true, CharSet = CharSet.Auto)]
        public static extern bool SHGetPathFromIDList(IntPtr pidl, IntPtr pszPath);
        [DllImport("shell32.dll", PreserveSig = true, CharSet = CharSet.Auto)]
        public static extern int SHGetSpecialFolderLocation(IntPtr hwnd, int csidl, ref IntPtr ppidl);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);
    }
    public enum BrowseForFolderMessages
    {
        BFFM_ENABLEOK = 0x465,
        BFFM_INITIALIZED = 1,
        BFFM_IUNKNOWN = 5,
        BFFM_SELCHANGED = 2,
        BFFM_SETEXPANDED = 0x46a,
        BFFM_SETOKTEXT = 0x469,
        BFFM_SETSELECTIONA = 0x466,
        BFFM_SETSELECTIONW = 0x467,
        BFFM_SETSTATUSTEXTA = 0x464,
        BFFM_SETSTATUSTEXTW = 0x468,
        BFFM_VALIDATEFAILEDA = 3,
        BFFM_VALIDATEFAILEDW = 4
    }
    [Flags, Serializable]
    public enum BrowseFlags
    {
        BIF_DEFAULT = 0x0000,
        BIF_BROWSEFORCOMPUTER = 0x1000,
        BIF_BROWSEFORPRINTER = 0x2000,
        BIF_BROWSEINCLUDEFILES = 0x4000,
        BIF_BROWSEINCLUDEURLS = 0x0080,
        BIF_DONTGOBELOWDOMAIN = 0x0002,
        BIF_EDITBOX = 0x0010,
        BIF_NEWDIALOGSTYLE = 0x0040,
        BIF_NONEWFOLDERBUTTON = 0x0200,
        BIF_RETURNFSANCESTORS = 0x0008,
        BIF_RETURNONLYFSDIRS = 0x0001,
        BIF_SHAREABLE = 0x8000,
        BIF_STATUSTEXT = 0x0004,
        BIF_UAHINT = 0x0100,
        BIF_VALIDATE = 0x0020,
        BIF_NOTRANSLATETARGETS = 0x0400,
    }
    public class FolderBrowser
    {
        private string m_strTitle;
        private BrowseFlags m_Flags;
        private string m_initDir;
        public FolderBrowser()
        {
            m_Flags = BrowseFlags.BIF_DEFAULT;
            m_strTitle = "";
        }
        public string DirectoryPath { get; private set; }
        public string DisplayName { get; private set; }
        public string Title
        {
            set { m_strTitle = value; }
        }
        public BrowseFlags Flags
        {
            set { m_Flags = value; }
        }
        public DialogResult ShowDialog()
        {
            BROWSEINFO bi = new BROWSEINFO();
            bi.pszDisplayName = IntPtr.Zero;
            bi.lpfn = IntPtr.Zero;
            bi.lpfn = BrowserCallBack;
            bi.lParam = IntPtr.Zero;
            bi.lpszTitle = "Select Folder";
            IntPtr idListPtr = IntPtr.Zero;
            IntPtr pszPath = IntPtr.Zero;
            try
            {
                if (m_strTitle.Length != 0)
                {
                    bi.lpszTitle = m_strTitle;
                }
                bi.ulFlags = (int)m_Flags;
                bi.pszDisplayName = Marshal.AllocHGlobal(256);
                // Call SHBrowseForFolder
                idListPtr = Win32SDK.SHBrowseForFolder(bi);
                // Check if the user cancelled out of the dialog or not.
                if (idListPtr == IntPtr.Zero)
                {
                    return DialogResult.Cancel;
                }
                // Allocate ncessary memory buffer to receive the folder path.
                pszPath = Marshal.AllocHGlobal(256);
                // Call SHGetPathFromIDList to get folder path.
                bool bRet = Win32SDK.SHGetPathFromIDList(idListPtr, pszPath);
                // Convert the returned native poiner to string.
                DirectoryPath = Marshal.PtrToStringAuto(pszPath);
                DisplayName = Marshal.PtrToStringAuto(bi.pszDisplayName);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return DialogResult.Abort;
            }
            finally
            {
                // Free the memory allocated by shell.
                if (idListPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(idListPtr);
                }
                if (pszPath != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pszPath);
                }
                Marshal.FreeHGlobal(bi.pszDisplayName);
            }
            return DialogResult.OK;
        }
        private IntPtr GetStartLocationPath()
        {
            return IntPtr.Zero;
        }
        public string InitDir
        {
            set { m_initDir = value; }
        }
        private int BrowserCallBack(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam)
        {
            if (uMsg == (int)BrowseForFolderMessages.BFFM_INITIALIZED)
            {
                Win32SDK.SendMessage(hWnd, (int)BrowseForFolderMessages.BFFM_SETSELECTIONW, 1, m_initDir);
            }
            return 0;
        }
    }
