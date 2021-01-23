    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Management;
    using System.Runtime.InteropServices;
    
    namespace DisplayTester
    {
        public partial class Form1 : Form
        {
            private int display_Current = Screen.AllScreens.Count();
            private int display_Maximum = Maximum();
            private int display_Attached = Attached();
    
            [DllImport("User32.dll")]
            private static extern bool EnumDisplayDevices(string lpDevice, int iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, int dwFlags);
    
            [StructLayout(LayoutKind.Sequential)]
            public struct DISPLAY_DEVICE
            {
                public int cb;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string DeviceName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
                public string DeviceString;
                public int StateFlags;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
                public string DeviceID;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
                public string DeviceKey;
    
                public DISPLAY_DEVICE(int flags)
                {
                    cb = 0;
                    StateFlags = flags;
                    DeviceName = new string((char)32, 32);
                    DeviceString = new string((char)32, 128);
                    DeviceID = new string((char)32, 128);
                    DeviceKey = new string((char)32, 128);
                    cb = Marshal.SizeOf(this);
                }
            }
    
            public Form1()
            {
                InitializeComponent();
                label_Active.Text = display_Current.ToString();
                label_Attachable.Text = display_Maximum.ToString();
                label_Attached.Text = display_Attached.ToString();
            }
    
            private static int Maximum()
            {
                DISPLAY_DEVICE lpDisplayDevice = new DISPLAY_DEVICE(0);
    
                int devNum = 0;
                while (EnumDisplayDevices(null, devNum, ref lpDisplayDevice, 0))
                {
                    ++devNum;
                }
                return devNum;
            }
    
            private static int Attached()
            {
                int monitors = 0;
                try
                {
                    ManagementObjectSearcher MonCount = new ManagementObjectSearcher("root\\CIMV2", "SELECT Service FROM Win32_PnPEntity WHERE Service = 'monitor'");
                    foreach (ManagementObject monitor in MonCount.Get())
                    {
                        monitors++;
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("Error: Couldn't count monitors, WMI:" + e.Message);
                }
                return monitors;
            }
        }
    }
