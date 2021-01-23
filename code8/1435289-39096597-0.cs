    public Expression<Func<DEVICE_TYPE, string>> DeviceExpression()
    {
        return  => "(" + DEV_CODE + ") " + DEVICE_NAME + " " + DEVICE_MARK;
    }
    public Expression<Func<DEVICE_TYPE, bool>> SearchDeviceExpression(string s)
    {
        return  => DeviceExpression() == s;
    }
