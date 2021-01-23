    using PcapDotNet.Core;
    using PcapDotNet.Core.Extensions;
    using PcapDotNet.Packets;
    using PcapDotNet.Packets.Ethernet;
    using PcapDotNet.Packets.IpV4;
    using PcapDotNet.Packets.Transport;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    namespace UDP
    {
    public static class NetworkDevice
    {
        private static string GetLocalMachineIpAddress()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                throw new Exception("Network is not available. Please check connection to the internet.");
            }
            using (Socket socket = new Socket(System.Net.Sockets.AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }
        public static PacketDevice GetIpv4PacketDevice()
        {
            string localMachineIpAddress = GetLocalMachineIpAddress();
            IEnumerable<LivePacketDevice> ipV4adapters = LivePacketDevice.AllLocalMachine.Where(w =>
                                                                        (w.Addresses.Select(s => s.Address.Family))
                                                                        .Contains(SocketAddressFamily.Internet));
            foreach (var adapter in ipV4adapters)
            {
                var adapterAddresses = adapter.Addresses
                    .Where(w => w.Address.Family == SocketAddressFamily.Internet)
                    .Select(s => ((IpV4SocketAddress)s.Address).Address.ToString());
                if (adapterAddresses.Contains(localMachineIpAddress))
                    return adapter;
            }
            throw new ArgumentException("System didn't find any adapter.");
        }
    }
    public static class DefaultGateway
    {
        private static IPAddress GetDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .FirstOrDefault(a => a != null);
        }
        private static string GetMacAddressFromResultOfARPcommand(string[] commandResult, string separator)
        {
            string macAddress = commandResult[3].Substring(Math.Max(0, commandResult[3].Length - 2))
                        + separator + commandResult[4] + separator + commandResult[5] + separator + commandResult[6]
                        + separator + commandResult[7] + separator
                        + commandResult[8].Substring(0, 2);
            return macAddress;
        }
        public static string GetMacAddress(char separator = ':')
        {
            IPAddress defaultGateway = GetDefaultGateway();
            if (defaultGateway == null)
            {
                throw new Exception("System didn't find the default gateway.");
            }
            string defaultGatewayIpAddress = defaultGateway.ToString();
            return GetMacAddress(defaultGatewayIpAddress, separator);
        }
        public static string GetMacAddress(string ipAddress, char separator)
        {
            Process process = new Process();
            process.StartInfo.FileName = "arp";
            process.StartInfo.Arguments = "-a " + ipAddress;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string strOutput = process.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');
            if (substrings.Length <= 8)
            {
                throw new Exception("System didn't find the default gateway mac address.");
            }
            return GetMacAddressFromResultOfARPcommand(substrings, separator.ToString());
        }
    }
    public class UdpProcessor
    {
        private string _destinationMacAddress;
        private string _destinationIPAddress;
        private ushort _destinationPort;
        private string _sourceMacAddress;
        private string _sourceIPAddress;
        private ushort _sourcePort;
        private static LivePacketDevice _device = null;
        public UdpProcessor(string destinationIp)
        {
            _sourcePort = 55555;
            _destinationPort = 44444;
            _device = NetworkDevice.GetIpv4PacketDevice() as LivePacketDevice;
            _destinationIPAddress = destinationIp;
            _sourceIPAddress = _device.Addresses[1].Address.ToString().Split(' ')[1]; //todo
            _sourceMacAddress = (_device as LivePacketDevice).GetMacAddress().ToString();
            _destinationMacAddress = DefaultGateway.GetMacAddress();
        }
        private EthernetLayer CreateEthernetLayer()
        {
            return new EthernetLayer
            {
                Source = new MacAddress(_sourceMacAddress),
                Destination = new MacAddress(_destinationMacAddress),
                EtherType = EthernetType.None,
            };
        }
        private IpV4Layer CreateIpV4Layer()
        {
            return new IpV4Layer
            {
                Source = new IpV4Address(_sourceIPAddress),
                CurrentDestination = new IpV4Address(_destinationIPAddress),
                Fragmentation = IpV4Fragmentation.None,
                HeaderChecksum = null,
                Identification = 123,
                Options = IpV4Options.None,
                Protocol = null,
                Ttl = 100,
                TypeOfService = 0,
            };
        }
        private UdpLayer CreateUdpLayer()
        {
            return new UdpLayer
            {
                SourcePort = _sourcePort,
                DestinationPort = _destinationPort,
                Checksum = null,
                CalculateChecksumValue = true,
            };
        }
        public void SendUDP()
        {
            EthernetLayer ethernetLayer = CreateEthernetLayer();
            IpV4Layer ipV4Layer = CreateIpV4Layer();
            UdpLayer udpLayer = CreateUdpLayer();
            PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, udpLayer);
            using (PacketCommunicator communicator = _device.Open(100, PacketDeviceOpenAttributes.Promiscuous, 1000))
            {
                communicator.SendPacket(builder.Build(DateTime.Now));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\r IP:Port = ");
            string ipAddress = Console.ReadLine();           
            new UdpProcessor(ipAddress).SendUDP();           
            Console.ReadKey();
        }
    }
    }
