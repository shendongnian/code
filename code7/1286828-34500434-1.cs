    using Microsoft.Phone.Info;
    
    object uniqueId;
    var hexString = string.Empty;
    if (DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out uniqueId))
         hexString = BitConverter.ToString((byte[])uniqueId).Replace("-", string.Empty);
            MessageBox.Show("myDeviceID:" + hexString);
