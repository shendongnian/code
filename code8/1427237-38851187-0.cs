       IUsbDevice wholeUsbDevice = PhysicalLibUSBDevice as IUsbDevice;
        if (!ReferenceEquals(wholeUsbDevice, null))
        {
            // This is a "whole" USB device. Before it can be used, 
            // the desired configuration and interface must be selected.
            // Select config #1
            wholeUsbDevice.SetConfiguration(1);
            // Claim interface #0.
            wholeUsbDevice.ClaimInterface(0);
        }
        // Create the reader and writer streams
        _libUsbReader = PhysicalLibUSBDevice.OpenEndpointReader(LibUsbDotNet.Main.ReadEndpointID.Ep01);
        _libUsbWriter = PhysicalLibUSBDevice.OpenEndpointWriter(LibUsbDotNet.Main.WriteEndpointID.Ep02);
        _libUsbReader.DataReceived += OnDataReceived;
        _libUsbReader.DataReceivedEnabled = true;
        _libUsbReader.ReadThreadPriority = System.Threading.ThreadPriority.Highest;
        _libUsbReader.ReadBufferSize = 32;
