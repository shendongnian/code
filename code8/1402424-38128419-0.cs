        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        using System.Management;    //used to perform WMI queries
        using System.Threading;
        using System.Runtime.InteropServices; // needed for marshalling
    
        namespace MissionControl
        {
            public partial class Control : Form
            {
                public Control()
                {
                    InitializeComponent();
                }
    
                // WndProc = Window Procedures: Every window has an associated     window procedure — a function that processes all messages sent 
            // or posted to all windows of the class. All aspects of a window's appearance and behavior depend on the window procedure's 
            // response to these messages. see https://msdn.microsoft.com/en-us/library/ms632593%28v=vs.85%29.aspx
            protected override void WndProc(ref Message m)
            {
                //you may find these definitions in dbt.h 
                const int WM_DEVICECHANGE = 0x0219; // in dbt.h, BroadcastSpecialMessage constants. 
                const int DBT_DEVICEARRIVAL = 0x8000;  // system detected a device arrived see dbt.h
                const int DBT_DEVICEREMOVECOMPLETE = 0x8004; //system detected a device removal see dbt.h
                const int DBT_DEVTYP_PORT = 0x00000003;  // serial, parallel in dbt.h
    
                switch (m.Msg)
                {
                    case WM_DEVICECHANGE:
                        switch (m.WParam.ToInt32())
                        {
                            case DBT_DEVICEARRIVAL:
                                {
                                    // Get the DBT_DEVTYP* as defined in dbt.h
                                    // We are looking for DBT_DEVTYP_PORT value = 3 which is Serial port
                                    int devTypeA = Marshal.ReadInt32(m.LParam, 4);
    
                                    if (devTypeA == DBT_DEVTYP_PORT)
                                    {
                                        rchtxbx_output.SelectedText = string.Empty;
                                        rchtxbx_output.SelectionFont = new Font(rchtxbx_output.SelectionFont, FontStyle.Bold);
                                        rchtxbx_output.SelectionColor = Color.Lime;
                                        rchtxbx_output.AppendText("\rSerial Port Connected\r\rList of Current Ports\r");
    
                                    }
                                    else
                                    {
                                        // We should never get in here but just in case do somethign rather than fall over
                                        rchtxbx_output.SelectedText = string.Empty;
                                        rchtxbx_output.SelectionFont = new Font(rchtxbx_output.SelectionFont, FontStyle.Bold);
                                        rchtxbx_output.SelectionColor = Color.Red;
                                        rchtxbx_output.AppendText("Non-Serial Port Connected\r");
                                    }
    
    
                                    //To prevent cross threading we will start the function call in its own thread
                                    // Create the thread object, passing in GetPortNum
                                    //ThreadA is the arrival thread (just connected)
                                    Thread ThreadA = new Thread(new ThreadStart(GetPortNum));
    
                                    // Start the thread via a ThreadStart delegate
                                    ThreadA.Start();
    
                                }
                                break;
                            case DBT_DEVICEREMOVECOMPLETE:
                                {
                                    // Get the DBT_DEVTYP* as defined in dbt.h
                                    // We are looking for DBT_DEVTYP_PORT value = 3 which is Serial port
                                    int devTypeD = Marshal.ReadInt32(m.LParam, 4);
    
                                    if (devTypeD == DBT_DEVTYP_PORT)
                                    {
                                        rchtxbx_output.SelectedText = string.Empty;
                                        rchtxbx_output.SelectionFont = new Font(rchtxbx_output.SelectionFont, FontStyle.Bold);
                                        rchtxbx_output.SelectionColor = Color.Lime;
                                        rchtxbx_output.AppendText("\rSerial Port Disconnected\r\rList of Current Ports\r");
                                    }
                                    else
                                    {
                                        // We should never get in here but just in case do something rather than fall over
                                        rchtxbx_output.SelectedText = string.Empty;
                                        rchtxbx_output.SelectionFont = new Font(rchtxbx_output.SelectionFont, FontStyle.Bold);
                                        rchtxbx_output.SelectionColor = Color.Red;
                                        rchtxbx_output.AppendText("Non-Serial Port Disconneted\r");
    
                                    }
    
                                    //To prevent cross threading we will start the function call in its own thread
                                    // Create the thread object, passing in GetPortNum
                                    //ThreadD is the departure thread (disconnected) 
                                    Thread ThreadD = new Thread(new ThreadStart(GetPortNum));
    
                                    // Start the thread via a ThreadStart delegate
                                    ThreadD.Start();
                                }
    
                                break;
                        }
    
                        break;
                }
                //we detect the media arrival event 
                base.WndProc(ref m);
            }
    
    
            private void btn_close_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void btn_clr_Click(object sender, EventArgs e)
            {
                rchtxbx_output.Clear();
            }
    
            private void GetPortNum()
            {
                //Windows Management Instrumentation (WMI) consists of a set of extensions to the Windows Driver Model that provides an 
                //operating system interface through which instrumented components provide information and notification. 
                // To work out the WMI to use, get the tool https://www.microsoft.com/en-us/download/details.aspx?id=8572
    
                //GUID (or UUID) is an acronym for 'Globally Unique Identifier' (or 'Universally Unique Identifier'). It is a 128-bit 
                //integer number used to identify resources. The term GUID is generally used by developers working with Microsoft 
                //technologies, while UUID is used everywhere else.
                // Get the list of ClassGUID from https://msdn.microsoft.com/en-us/library/windows/hardware/ff553426%28v=vs.85%29.aspx
    
                string comportnum = "";
                int textStart = 0;
                char[] textEnd = { ')' };
    
    
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                        "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    comportnum = queryObj["Name"].ToString(); // Get the name of the comm port
    
                    //Format the string to extract the comport number only
                    textStart = comportnum.IndexOf("(COM");
                    comportnum = comportnum.Remove(0, textStart + 4).TrimEnd(textEnd);
    
                    //To prevent cross threading use Invoke. We are writing to a control created in another thread.
                    rchtxbx_output.Invoke(new EventHandler(delegate
                    {
                        rchtxbx_output.SelectedText = string.Empty;
                        rchtxbx_output.SelectionFont = new Font(rchtxbx_output.SelectionFont, FontStyle.Bold);
                        rchtxbx_output.SelectionColor = Color.Lime; //set font colour
                        rchtxbx_output.AppendText("Comm Port = " + comportnum + "\r"); //add some text
                        rchtxbx_output.ScrollToCaret(); // move cursor to the end
                    }));
                }
            }
        }
    }
