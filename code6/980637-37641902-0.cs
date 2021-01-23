            /// <summary>
            /// Indicates if this device is running a version of Windows Phone 8.1. It use a dirty trick for detecting the OS major version
            /// based on the system firmware version format (8.1 is xxxx.xxxxx.xxxx.xxxx while 10 is xxxxx.xxxxx.xxxxx.xxxxx )
            /// moreover, the "deviceInfo.id" is not implemented on Windows Phone 8.1, but it is on Windows Phone 10
            /// </summary>
            /// <returns></returns>
            public static bool liIsWindowsPhone81(bool basedOnDeviceInfoId)
            {
                EasClientDeviceInformation deviceInfo = new Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
                bool isWin81 = false;
                if (basedOnDeviceInfoId)
                {
                    try
                    {
                        var deviceInfoId = deviceInfo.Id;
                    }
                    catch
                    {
                        isWin81 = true;
                    }
                }
                else
                {
                    string firmwareVersion = deviceInfo.SystemFirmwareVersion.Trim();
                    string[] parts = firmwareVersion.Split('.');
                    if (parts[0].Length == 4 && parts[1].Length == 5 && parts[2].Length == 4 && parts[3].Length == 4)
                    {
                        isWin81 = true;
                    }
                }
    
                return isWin81;
            }
