    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Diagnostics;
    using Windows.Networking.Proximity;
    using Windows.Storage.Streams;
    
    namespace hsProximity
    {
        public delegate void cbUID([MarshalAs(UnmanagedType.LPWStr)] string AStr);
        public delegate void cbState(int AStatus);
    
        [ComVisible(true), Guid("81C99F84-AA95-41A5-868E-62FAC8FAC263"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IHSProximityInterface
        {
            bool doInitialise(Int32 cbUIDPtr, Int32 cbStatePtr, out String AMessage);
        }
    
        [ClassInterface(ClassInterfaceType.None), ComVisible(true)]
        public class MainClass : IHSProximityInterface
        {
            public ProximityDevice proximityDevice;
            public List<NdefRecord> recordList;
            IntPtr ptr;
            cbUID callbackUID;
            cbState callbackState;
    
            public bool doInitialise(Int32 cbUIDPtr, Int32 cbStatePtr, out String AMessage)
            {
                recordList = new List<NdefRecord>();
                proximityDevice = ProximityDevice.GetDefault();
    
                ptr = new IntPtr(cbUIDPtr);
                callbackUID = (cbUID)Marshal.GetDelegateForFunctionPointer(ptr, typeof(cbUID));
    
                ptr = new IntPtr(cbStatePtr);
                callbackState = (cbState)Marshal.GetDelegateForFunctionPointer(ptr, typeof(cbState));
    
                if (proximityDevice != null)
                {
                    proximityDevice.DeviceArrived += ProximityDeviceArrived;
                    proximityDevice.DeviceDeparted += ProximityDeviceDeparted;
                    proximityDevice.SubscribeForMessage("NDEF", MessageReceivedHandler);
                    AMessage = "Proximity device initialized. ID: " + proximityDevice.DeviceId;
                    return true;
                }
                else
                {
                    AMessage = "Failed to initialize proximity device.";
                    return false;
                }
            }
    
            public void ProximityDeviceArrived(ProximityDevice sender)
            {
                callbackState(1);
            }
    
            public void ProximityDeviceDeparted(ProximityDevice sender)
            {
                callbackState(0);
            }
    
            public void MessageReceivedHandler(ProximityDevice sender, ProximityMessage message)
            {
                recordList.Clear();
                callbackUID(ParseNDEF(message));
            }
        }
    }
