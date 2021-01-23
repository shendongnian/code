    public async void TestFunction()
    {
        byte DataToBeSend = 100;
        byte ReceivedData;
        ReceivedData = await I2cHelper.WriteRead_OneByte(DataToBeSend);
    }
