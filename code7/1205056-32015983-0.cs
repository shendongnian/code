    class DeviceIdProvider : IDeviceIdProvider
    {
        public string GetDeviceId()
        {
            object objUniqueID;
            if(DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out objUniqueID)) {
                return ConvertEx.HexStringEncode((byte[])objUniqueID);
            }
            else {
                return "Unknown";
            }
        }
    }
