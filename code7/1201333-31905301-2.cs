    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using WIA;
    public static class WiaCopy
    {
        public static IEnumerable<IDeviceInfo> GetAppleDevices()
        {
            return new DeviceManager().DeviceInfos.Cast<IDeviceInfo>().Where(di =>
                di.Type == WiaDeviceType.CameraDeviceType
                && di.Properties["Manufacturer"].get_Value() == "Apple Inc."
                && di.Properties["Description"].get_Value() == "Apple iPhone");
        }
        public static IEnumerable<Item> GetImgItems(IDeviceInfo deviceInfo)
        {
            var device = deviceInfo.Connect();
            return device.Items.Cast<Item>().Where(i => i.Properties["Item Name"].get_Value().ToString().StartsWith("IMG"));
        }
        public static void TransferItem(Item item, string path)
        {
            // TODO: should use .mov for videos here
            var targetName = item.Properties["Item Name"].get_Value() + ".jpg";
            Directory.CreateDirectory(path);
            item.Transfer().SaveFile(Path.Combine(path, targetName));
        }
    }
