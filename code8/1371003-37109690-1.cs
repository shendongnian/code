    // you'll have to figure out the type of the `child.Properties`
    public static T GetValue<T>(TypeOfChildProperties properties, string name, T defaultValue = default(T))
    {
        var value = properties[name];
        if (value == null)
            return defaultValue;
        return (T)value;
        // if you have some cast problems, you could use this:
        return (T)Convert.ChangeType(value, typeof(T));
    }
---
    activeSyncPhone.Cn = GetValue<string>(child.Properties, "cn");
    activeSyncPhone.DistinguishedName = GetValue<string>(child.Properties, "distinguishedName");
    activeSyncPhone.InstanceType =  GetValue<int>(child.Properties, "instanceType");
    activeSyncPhone.MsExchDeviceIMEI = GetValue<string>(child.Properties, "msExchDeviceIMEI", "Could not find IMEI");
