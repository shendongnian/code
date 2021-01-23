    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    
    namespace WpfApplication2
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private IntPtr GetHandle()
            {
                var helper = new WindowInteropHelper(this);
                var handle = helper.Handle;
                return handle;
            }
    
            private void ButtonClientToScreen_Click(object sender, RoutedEventArgs e)
            {
                // convert a point in window coords to screen coords
                var handle = GetHandle();
                var point = new NativePoint {x = 50, y = 50};
                var clientToScreen = NativeMethods.ClientToScreen(handle, ref point);
                if (clientToScreen)
                {
                    MessageBox.Show(this, string.Format("ClientToScreen: {0}", point));
                }
            }
    
            private void ButtonGetClientRect_Click(object sender, RoutedEventArgs e)
            {
                // get window size
                var handle = GetHandle();
                NativeRect rect;
                var clientRect = NativeMethods.GetClientRect(handle, out rect);
                if (clientRect)
                {
                    MessageBox.Show(this, string.Format("GetClientRect: {0}", rect));
                }
            }
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeRect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
    
            public override string ToString()
            {
                return $"Left: {left}, Top: {top}, Right: {right}, Bottom: {bottom}";
            }
        }
    
    
        [StructLayout(LayoutKind.Sequential)]
        public struct NativePoint
        {
            public int x;
            public int y;
    
            public override string ToString()
            {
                return $"X: {x}, Y: {y}";
            }
        }
    
        public class NativeMethods
        {
            [DllImport("user32.dll", EntryPoint = "GetClientRect")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetClientRect([In] IntPtr hWnd, [Out] out NativeRect lpRect);
    
            [DllImport("user32.dll", EntryPoint = "ClientToScreen")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool ClientToScreen([In] IntPtr hWnd, ref NativePoint lpPoint);
        }
    }
