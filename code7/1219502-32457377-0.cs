	namespace ConsoleApplication7
	{
		using System;
		using System.Collections.Generic;
		using PcapDotNet.Core;
		using PcapDotNet.Packets;
		internal class Program
		{
			private static void Main(string[] args)
			{
				IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
				if (allDevices.Count == 0)
				{
					Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
					return;
				}
				
				for (int i = 0; i != allDevices.Count; ++i)
				{
					var device = allDevices[i];
					Console.Write((i + 1) + ". " + device.Name);
					
					if (device.Description != null)
					{
						Console.WriteLine(" (" + device.Description + ")");
					}
					else
					{
						Console.WriteLine(" (No description available)");
					}
				}
				int deviceIndex;
				do
				{
					Console.WriteLine("Enter the interface number (1-" + allDevices.Count + "):");
					var deviceIndexString = Console.ReadLine();
					if (!int.TryParse(deviceIndexString, out deviceIndex) || deviceIndex < 1 || deviceIndex > allDevices.Count)
					{
						deviceIndex = 0;
					}
				}
				while (deviceIndex == 0);
				
				var selectedDevice = allDevices[deviceIndex - 1];
				
				using (var communicator = selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
				{
					Console.WriteLine("Listening on " + selectedDevice.Description + "...");
					communicator.ReceivePackets(0, packet => PacketHandler(selectedDevice, packet));
				}
			}
		
			private static void PacketHandler(PacketDevice device, Packet packet)
			{
				Console.WriteLine("[{0}] {1} {2}", device.Name, packet.Timestamp.ToString("hh:mm:ss.fff"), packet.Length);
			}
		}
	}
----------
	1. rpcap://\Device\NPF_{0CDD10C5-9C40-47BD-811D-7CD24547CD28} (Network adapter 'Microsoft' on local host)
	2. rpcap://\Device\NPF_{3C97403E-012B-4912-96B1-F8E246F93BA0} (Network adapter 'Sun' on local host)
	3. rpcap://\Device\NPF_{06217B0B-1804-4ADD-9BEE-4A7EBC63B009} (Network adapter 'Microsoft' on local host)
	4. rpcap://\Device\NPF_{C189488C-4DD5-4410-981B-A5929234AC09} (Network adapter 'Intel(R) 82579LM Gigabit Network Connection' on local host)
	5. rpcap://\Device\NPF_{40199909-A7A1-4549-8D06-9DCE66F24A7E} (Network adapter 'Microsoft' on local host)
	
	Enter the interface number (1-5): 4
	Listening on Network adapter 'Intel(R) 82579LM Gigabit Network Connection' on local host...
	[rpcap://\Device\NPF_{C189488C-4DD5-4410-981B-A5929234AC09}] 01:59:49.552 55
	[rpcap://\Device\NPF_{C189488C-4DD5-4410-981B-A5929234AC09}] 01:59:49.552 60
	[rpcap://\Device\NPF_{C189488C-4DD5-4410-981B-A5929234AC09}] 01:59:49.848 60
	[rpcap://\Device\NPF_{C189488C-4DD5-4410-981B-A5929234AC09}] 01:59:49.848 54
	[rpcap://\Device\NPF_{C189488C-4DD5-4410-981B-A5929234AC09}] 01:59:49.958 55
	[rpcap://\Device\NPF_{C189488C-4DD5-4410-981B-A5929234AC09}] 01:59:49.958 55
