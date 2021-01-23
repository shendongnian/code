    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using NativeWifi;
    public static class WlanRadio
    {
        public static string[] GetInterfaceNames()
        {
            using (var client = new WlanClient())
            {
                return client.Interfaces.Select(x => x.InterfaceName).ToArray();
            }
        }
        public static bool TurnOn(string interfaceName)
        {
            var interfaceGuid = GetInterfaceGuid(interfaceName);
            if (!interfaceGuid.HasValue)
                return false;
            return SetRadioState(interfaceGuid.Value, Wlan.Dot11RadioState.On);
        }
        public static bool TurnOff(string interfaceName)
        {
            var interfaceGuid = GetInterfaceGuid(interfaceName);
            if (!interfaceGuid.HasValue)
                return false;
            return SetRadioState(interfaceGuid.Value, Wlan.Dot11RadioState.Off);
        }
        private static Guid? GetInterfaceGuid(string interfaceName)
        {
            using (var client = new WlanClient())
            {
                return client.Interfaces.FirstOrDefault(x => x.InterfaceName == interfaceName)?.InterfaceGuid;
            }
        }
        private static bool SetRadioState(Guid interfaceGuid, Wlan.Dot11RadioState radioState)
        {
            var state = new Wlan.WlanPhyRadioState
            {
                dwPhyIndex = (int)Wlan.Dot11PhyType.Any,
                dot11SoftwareRadioState = radioState,
            };
            var size = Marshal.SizeOf(state);
            var pointer = IntPtr.Zero;
            try
            {
                pointer = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(state, pointer, false);
                var clientHandle = IntPtr.Zero;
                try
                {
                    uint negotiatedVersion;
                    var result = Wlan.WlanOpenHandle(
                        Wlan.WLAN_CLIENT_VERSION_LONGHORN,
                        IntPtr.Zero,
                        out negotiatedVersion,
                        out clientHandle);
                    if (result != 0)
                        return false;
                    result = Wlan.WlanSetInterface(
                        clientHandle,
                        interfaceGuid,
                        Wlan.WlanIntfOpcode.RadioState,
                        (uint)size,
                        pointer,
                        IntPtr.Zero);
                    return (result == 0);
                }
                finally
                {
                    Wlan.WlanCloseHandle(
                        clientHandle,
                        IntPtr.Zero);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(pointer);
            }
        }
		public static string[] GetAvailableNetworkProfileNames(string interfaceName)
		{
			using (var client = new WlanClient())
			{
				var wlanInterface = client.Interfaces.FirstOrDefault(x => x.InterfaceName == interfaceName);
				if (wlanInterface == null)
					return Array.Empty<string>();
				return wlanInterface.GetAvailableNetworkList(Wlan.WlanGetAvailableNetworkFlags.IncludeAllManualHiddenProfiles)
					.Select(x => x.profileName)
					.Where(x => !string.IsNullOrEmpty(x))
					.ToArray();
			}
		}
		public static void ConnectNetwork(string interfaceName, string profileName)
		{
			using (var client = new WlanClient())
			{
				var wlanInterface = client.Interfaces.FirstOrDefault(x => x.InterfaceName == interfaceName);
				if (wlanInterface == null)
					return;
				wlanInterface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName);
			}
		}
    }
