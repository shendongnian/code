    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    
    namespace NetworkIdentifier
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var macAddressOfGateway = GetMacAddressOfGateway();
                Console.WriteLine(macAddressOfGateway);
                Console.ReadLine();
            }
    
            private static string GetMacAddressOfGateway()
            {
                var networkInterface = GetBestNetworkInterface();
                var gatewayAddress = networkInterface.GetIPProperties().GatewayAddresses.FirstOrDefault();
                if (gatewayAddress == null)
                {
                    throw new InvalidOperationException("No gateway!");
                }
    
                var mac = GetMacAddress(gatewayAddress.Address);
    
                return MacToString(mac);
            }
    
            private static string MacToString(byte[] mac)
            {
                return string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", mac[0], mac[1], mac[2], mac[3], mac[4], mac[5]);
            }
    
            public static NetworkInterface GetBestNetworkInterface()
            {
                var publicIpAddress = new IPAddress(0x08080808); // Googles DNS IP of 8.8.8.8 (Seems like a relatively safe hardcoded IP to pick :))
                var ipv4AddressAsUInt32 = BitConverter.ToUInt32(publicIpAddress.GetAddressBytes(), 0);
                uint interfaceindex;
                var result = Win32ApiCalls.GetBestInterface(ipv4AddressAsUInt32, out interfaceindex);
                if (result != 0)
                {
                    throw new Win32Exception(result);
                }
    
                var networkCards = NetworkInterface.GetAllNetworkInterfaces().Where(x => x.OperationalStatus == OperationalStatus.Up);
                return networkCards.FirstOrDefault(networkInterface => networkInterface.GetIPProperties().GetIPv4Properties().Index == interfaceindex);
            }
    
            public static IPAddress GetDefaultGateway()
            {
                var networkInterface = GetBestNetworkInterface();
                if (networkInterface == null) return null;
                var address = networkInterface.GetIPProperties().GatewayAddresses.FirstOrDefault();
                return address.Address;
            }
    
            public static byte[] GetMacAddress(IPAddress address)
            {
                byte[] mac = new byte[6];
                uint len = (uint)mac.Length;
                byte[] addressBytes = address.GetAddressBytes();
                uint dest = ((uint)addressBytes[3] << 24)
                  + ((uint)addressBytes[2] << 16)
                  + ((uint)addressBytes[1] << 8)
                  + ((uint)addressBytes[0]);
                if (Win32ApiCalls.SendARP(dest, 0, mac, ref len) != 0)
                {
                    throw new Exception("The ARP request failed.");
                }
                return mac;
            }
        }
    
        public static class Win32ApiCalls
        {
            [DllImport("iphlpapi.dll", CharSet = CharSet.Auto)]
            public static extern int GetBestInterface(UInt32 destAddr, out UInt32 bestIfIndex);
    
            [DllImport("iphlpapi.dll", ExactSpelling = true)]
            public static extern int SendARP(uint destIP, uint srcIP, byte[] macAddress, ref uint macAddressLength);
        }
    }
