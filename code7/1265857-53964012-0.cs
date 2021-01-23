               var deviceDefinitions = new Collection<DeviceDefinition>();
                var spDeviceInterfaceData = new SpDeviceInterfaceData();
                var spDeviceInfoData = new SpDeviceInfoData();
                var spDeviceInterfaceDetailData = new SpDeviceInterfaceDetailData();
                spDeviceInterfaceData.CbSize = (uint)Marshal.SizeOf(spDeviceInterfaceData);
                spDeviceInfoData.CbSize = (uint)Marshal.SizeOf(spDeviceInfoData);
                var guidString = ClassGuid.ToString();
                var copyOfClassGuid = new Guid(guidString);
                var i = APICalls.SetupDiGetClassDevs(ref copyOfClassGuid, IntPtr.Zero, IntPtr.Zero, APICalls.DigcfDeviceinterface | APICalls.DigcfPresent);
                if (IntPtr.Size == 8)
                {
                    spDeviceInterfaceDetailData.CbSize = 8;
                }
                else
                {
                    spDeviceInterfaceDetailData.CbSize = 4 + Marshal.SystemDefaultCharSize;
                }
                var x = -1;
                while (true)
                {
                    x++;
                    var isSuccess = APICalls.SetupDiEnumDeviceInterfaces(i, IntPtr.Zero, ref copyOfClassGuid, (uint)x, ref spDeviceInterfaceData);
                    if (!isSuccess)
                    {
                        var errorCode = Marshal.GetLastWin32Error();
                        if (errorCode == APICalls.ERROR_NO_MORE_ITEMS)
                        {
                            break;
                        }
                        throw new Exception($"Could not enumerate devices. Error code: {errorCode}");
                    }
                    isSuccess = APICalls.SetupDiGetDeviceInterfaceDetail(i, ref spDeviceInterfaceData, ref spDeviceInterfaceDetailData, 256, out _, ref spDeviceInfoData);
                    WindowsDeviceBase.HandleError(isSuccess, "Could not get device interface detail");
                    //Note this is a bit nasty but we can filter Vid and Pid this way I think...
                    var vendorHex = vendorId?.ToString("X").ToLower().PadLeft(4, '0');
                    var productIdHex = productId?.ToString("X").ToLower().PadLeft(4, '0');
                    if (vendorId.HasValue && !spDeviceInterfaceDetailData.DevicePath.ToLower().Contains(vendorHex)) continue;
                    if (productId.HasValue && !spDeviceInterfaceDetailData.DevicePath.ToLower().Contains(productIdHex)) continue;
                    var deviceDefinition = GetDeviceDefinition(spDeviceInterfaceDetailData.DevicePath);
                    deviceDefinitions.Add(deviceDefinition);
                }
                APICalls.SetupDiDestroyDeviceInfoList(i);
                return deviceDefinitions;
