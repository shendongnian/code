using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Threading;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.SourceInitialized += MainWindow_SourceInitialized;
            this.WindowStyle = WindowStyle.None;
            this.Loaded += Window_Loaded;
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();
        }
        private bool _enableOverride;
        internal class NativeMethods
        {
            public const int WM_WINDOWPOSCHANGING = 0x46;
            public const int WM_WINDOWPOSCHANGED = 0x47;
            public const int GWL_HWNDPARENT = -8;
            public const int SW_SHOW = 1;
            [Flags]
            public enum SetWindowPosFlags
            {
                SWP_NOSIZE = 0x1,
                SWP_NOMOVE = 0x2,
                SWP_NOZORDER = 0x4,
                SWP_NOREDRAW = 0x8,
                SWP_NOACTIVATE = 0x10,
                SWP_FRAMECHANGED = 0x20,
                SWP_DRAWFRAME = SWP_FRAMECHANGED,
                SWP_SHOWWINDOW = 0x40,
                SWP_HIDEWINDOW = 0x80,
                SWP_NOCOPYBITS = 0x100,
                SWP_NOOWNERZORDER = 0x200,
                SWP_NOREPOSITION = SWP_NOOWNERZORDER,
                SWP_NOSENDCHANGING = 0x400,
                SWP_DEFERERASE = 0x2000,
                SWP_ASYNCWINDOWPOS = 0x4000
            }
            public enum WindowZOrder
            {
                HWND_TOP = 0,
                HWND_BOTTOM = 1,
                HWND_TOPMOST = -1,
                HWND_NOTOPMOST = -2
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct WINDOWPOS
            {
                public IntPtr hWnd;
                public IntPtr hwndInsertAfter;
                public int x;
                public int y;
                public int cx;
                public int cy;
                public SetWindowPosFlags flags;
                // Returns the WINDOWPOS structure pointed to by the lParam parameter
                // of a WM_WINDOWPOSCHANGING or WM_WINDOWPOSCHANGED message.
                public static WINDOWPOS FromMessage(IntPtr lParam)
                {
                    // Marshal the lParam parameter to an WINDOWPOS structure,
                    // and return the new structure
                    return (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));
                }
                // Replaces the original WINDOWPOS structure pointed to by the lParam
                // parameter of a WM_WINDOWPOSCHANGING or WM_WINDOWPSCHANGING message
                // with this one, so that the native window will be able to see any
                // changes that we have made to its values.
                public void UpdateMessage(IntPtr lParam)
                {
                    // Marshal this updated structure back to lParam so the native
                    // window can respond to our changes.
                    // The old structure that it points to should be deleted, too.
                    Marshal.StructureToPtr(this, lParam, true);
                }
            }
        }
        public static class HWND
        {
            public static readonly IntPtr
            NOTOPMOST = new IntPtr(-2),
            BROADCAST = new IntPtr(0xffff),
            TOPMOST = new IntPtr(-1),
            TOP = new IntPtr(0),
            BOTTOM = new IntPtr(1);
        }
        public static class SWP
        {
            public static readonly int
            NOSIZE = 0x0001,
            NOMOVE = 0x0002,
            NOZORDER = 0x0004,
            NOREDRAW = 0x0008,
            NOACTIVATE = 0x0010,
            DRAWFRAME = 0x0020,
            FRAMECHANGED = 0x0020,
            SHOWWINDOW = 0x0040,
            HIDEWINDOW = 0x0080,
            NOCOPYBITS = 0x0100,
            NOOWNERZORDER = 0x0200,
            NOREPOSITION = 0x0200,
            NOSENDCHANGING = 0x0400,
            DEFERERASE = 0x2000,
            ASYNCWINDOWPOS = 0x4000;
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpWindowClass, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hwnd, int command);
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //ensure we don't overlap the taskbar.
            SetWindowPos(new WindowInteropHelper(this).Handle, HWND.BOTTOM, 0, 0, 0, 0, SWP.SHOWWINDOW | SWP.NOMOVE | SWP.NOOWNERZORDER | SWP.NOSIZE | SWP.NOACTIVATE);
            IntPtr task = FindWindow("Shell_TrayWnd", "");
            ShowWindow(task, NativeMethods.SW_SHOW);
            _enableOverride = true;
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (_enableOverride)
            {
                if (msg == NativeMethods.WM_WINDOWPOSCHANGING)
                {
                    Debug.WriteLine("WM_WINDOWPOSCHANGING");
                    // Extract the WINDOWPOS structure corresponding to this message
                    //lParam has the ptr to a WindowsPos structure if its our WM_WINDOWPOSCHANGING struct
                    NativeMethods.WINDOWPOS wndPos = NativeMethods.WINDOWPOS.FromMessage(lParam);
                    wndPos.flags = wndPos.flags | NativeMethods.SetWindowPosFlags.SWP_NOZORDER;
                    wndPos.UpdateMessage(lParam);
                    //handled = true;
                }
            }
            return IntPtr.Zero;
        }
        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            IntPtr hprog = FindWindowEx(
                           FindWindowEx(
                               FindWindow("Progman", "Program Manager"),
                               IntPtr.Zero, "SHELLDLL_DefView", ""
                           ),
                           IntPtr.Zero, "SysListView32", "FolderView"
                       );
            SetWindowLong(hWnd, NativeMethods.GWL_HWNDPARENT, hprog);
        }
    }
}
