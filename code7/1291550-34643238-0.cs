    foreach (dynamic mDevice in dynamicList)
    {
        object mDeviceProperties = mDevice.Value;
        var mobileDevice = JsonConvert.DeserializeObject<MobileDevice>(mDeviceProperties.ToString());
    }
