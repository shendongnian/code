    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            private readonly List<IntPtr> _dcs = new List<IntPtr>();
    
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var hdc = NativeMethods.GetDC(IntPtr.Zero);
                if (hdc == IntPtr.Zero)
                    throw new InvalidOperationException();
                if (!NativeMethods.EnumDisplayMonitors(hdc, IntPtr.Zero, Monitorenumproc, IntPtr.Zero))
                    throw new InvalidOperationException();
                if (NativeMethods.ReleaseDC(IntPtr.Zero, hdc) == 0)
                    throw new InvalidOperationException();
    
                foreach (var monitorDc in _dcs)
                {
                    // do something cool !   
                }
            }
    
            private int Monitorenumproc(IntPtr param0, IntPtr param1, ref tagRECT param2, IntPtr param3)
            {
                // optional actually ...
                var info = new MonitorInfo {cbSize = (uint) Marshal.SizeOf<MonitorInfo>()};
                if (!NativeMethods.GetMonitorInfoW(param0, ref info))
                    throw new InvalidOperationException();
    
                _dcs.Add(param1); // grab DC for current monitor !
    
                return 1;
            }
        }
    
    
        public class NativeMethods
        {
            [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
            public static extern int ReleaseDC([In] IntPtr hWnd, [In] IntPtr hDC);
    
            [DllImport("user32.dll", EntryPoint = "GetDC")]
            public static extern IntPtr GetDC([In] IntPtr hWnd);
    
            [DllImport("user32.dll", EntryPoint = "GetMonitorInfoW")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetMonitorInfoW([In] IntPtr hMonitor, ref MonitorInfo lpmi);
    
            [DllImport("user32.dll", EntryPoint = "EnumDisplayMonitors")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnumDisplayMonitors([In] IntPtr hdc, [In] IntPtr lprcClip, MONITORENUMPROC lpfnEnum,
                IntPtr dwData);
        }
    
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int MONITORENUMPROC(IntPtr param0, IntPtr param1, ref tagRECT param2, IntPtr param3);
    
        [StructLayout(LayoutKind.Sequential)]
        public struct MonitorInfo
        {
            public uint cbSize;
            public tagRECT rcMonitor;
            public tagRECT rcWork;
            public uint dwFlags;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct tagRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    }
