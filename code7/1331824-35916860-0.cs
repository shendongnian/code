    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace OneMachine
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string clientMAC = "XX-XX-XX-XX-XX-XX";       //  put the correct value here when you know it
                string thisComputerMAC = GetMACAddress2();
    
                Console.WriteLine("MAC:" + thisComputerMAC);   // remove this when necessary
    
                if (clientMAC == thisComputerMAC)
                {
                    
                    Console.WriteLine("this is the right computer");
                } else
                {
                    Console.WriteLine("PROGRAM WONT RUN ON THIS COMPUTER");
                }
    
    
            }
              
            public static string GetMACAddress2()
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                } return sMacAddress;
            }
    
    
        }
    }
