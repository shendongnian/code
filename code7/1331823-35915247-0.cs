    public static async Task<bool> GetBluetoothIsEnabledAsync()
    {
        var radios = await Radio.GetRadiosAsync();
        var bluetoothRadio = radios.FirstOrDefault(radio => radio.Kind == RadioKind.Bluetooth);
        return bluetoothRadio != null && bluetoothRadio.State == RadioState.On;
    }
