    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using DirectShowLib;
    
    namespace Test
    {
        static class Program
        {
            [STAThread]
    
            static void Main()
            {
                using (System.Threading.Mutex mutex = new System.Threading.Mutex(false, "Global\\" + appGuid))
                {
                    if (!mutex.WaitOne(0, false))
                    {
                        return;
                    }
    
                    DsDevice[] capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
    
                    foreach (var device in capDevices)
                    {
                        if (device.DevicePath == @"@device:pnp:\\?\pci#ven_1131&dev_7160&subsys_12abf50a&rev_03#6&37bccbbe&0&000800e1#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\{6f814be9-9af6-43cf-9249-c0340100021c}")
                        {
                            IFilterGraph2 m_FilterGraph = (IFilterGraph2)new FilterGraph();
    
                            IBaseFilter capFilter = null;
                            ICaptureGraphBuilder2 capGraph = null;
    
                            capGraph = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
    
                            int hr;
    
                            hr = capGraph.SetFiltergraph(m_FilterGraph);
                            hr = m_FilterGraph.AddSourceFilterForMoniker(device.Mon, null, device.Name, out capFilter);
    
                            IAMAnalogVideoDecoder videoDec = capFilter as IAMAnalogVideoDecoder;
    
                            bool signalDetected = false;
    
                            hr = videoDec.get_HorizontalLocked(out signalDetected);
    
                            if (signalDetected)
                            {
                                System.Diagnostics.Process.Start(@"C:\Users\PC\Documents\HIDDEN_FOLDER\WirecastLaunch.wcst");
                                return;
                            }
                            else
                            {
                                // Poll for 'signal' change
                            }
    
                            break;
                        }
                    }
    
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }
    
            private static string appGuid = "z0a76b5a-02cd-15c5-b9d9-d303zcdde7b9";
        }
    }
