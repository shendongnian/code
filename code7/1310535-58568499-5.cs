    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DispSetEx
    {
        class Program
        {
    
    
    
            [DllImport("DpiHelper.dll")]
            static public extern void PrintDpiInfo();
    
            [DllImport("DpiHelper.dll")]
            static public extern int SetDPIScaling(Int32 adapterIDHigh, UInt32 adapterIDlow, UInt32 sourceID, UInt32 dpiPercentToSet);
            [DllImport("DpiHelper.dll")]
            static public extern void RestoreDPIScaling();
    
            static void Main(string[] args)
            {
                if ((args.Length % 3) != 0)
                {
                    Console.WriteLine("wrong parameters");
                    return;
                }
    
    //print the DPI info, you need to set the command line parameters
    //according to this
                PrintDpiInfo();
    
        //commandline parameters should be of groups of three
        //each groups's tree paramters control a desktop's setting
        //in each group:
        //GPUIdhigh.GPUIdlow DesktopIndexInGPU DPIScalingValue
        //for example:
        //    0.1234 0 100 //set the DPI scaling to 100 for desktop 0 on GPU 0.1234
        //    0.4567 0 125 //set the DPI scaling to 125 for desktop 0 on GPU 0.5678
        //    0.4567 1 150 //set the DPI scaling to 150 for desktop 1 on GPU 0.5678
        //in most cases GPUIdhigh is 0.
        //you can use the monitor name to identify which is which easily
        //you need to set the command line parameters according to the result of PrintDpiInfo
        //e.g. you should only set the DPI scaling to a value that is supported by 
        //that desktop. 
            
                for (int i = 0; i < args.Length / 3; i++)
                {
                    string[] sa = args[i * 3].Split(new char[] { '.' });
                    
                    Int32 adapterHigh = Int32.Parse(sa[0]);
                    UInt32 adapterLow = UInt32.Parse(sa[1]);
                    UInt32 source = UInt32.Parse(args[i * 3 + 1]);
                    UInt32 dpiscale = UInt32.Parse(args[i * 3 + 2]);
    
                    SetDPIScaling(adapterHigh, adapterLow, source,dpiscale);
                }
    
                Console.WriteLine("Press any key to resotre the settings...");
                Console.ReadKey();
    
                RestoreDPIScaling();  
            }
        }
    }
