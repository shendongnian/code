    using System.Diagnostics;
    using NativeWifi;
    public static class WlanRadio
    {
        public static void CheckInterfaceStates()
        {
            using (var client = new WlanClient())
            {
                foreach (var @interface in client.Interfaces)
                {
                    Trace.WriteLine($"[{@interface.InterfaceName}]");
                    foreach (var state in @interface.RadioState.PhyRadioState)
                    {
                        Trace.WriteLine($"PhyIndex: {state.dwPhyIndex}");
                        Trace.WriteLine($"SoftwareRadioState: {state.dot11SoftwareRadioState}");
                        Trace.WriteLine($"HardwareRadioState: {state.dot11HardwareRadioState}");
                    }
                }
            }
        }
    }
