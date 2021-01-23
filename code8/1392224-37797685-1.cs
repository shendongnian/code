    // Create and initialize a new publisher instance.
    BluetoothLEAdvertisementPublisher publisher = new BluetoothLEAdvertisementPublisher();
    // Add a manufacturer-specific section:
    var manufacturerData = new BluetoothLEManufacturerData();
    // Set the company ID for the manufacturer data.
    // 0x004C   Apple, Inc.
    manufacturerData.CompanyId = 0x004c;
    // Create the payload
    var writer = new DataWriter();
    byte[] dataArray = new byte[] {
        // last 2 bytes of Apple's iBeacon
        0x02, 0x15,
        // UUID e2 c5 6d b5 df fb 48 d2 b0 60 d0 f5 a7 10 96 e0
        0xe2, 0xc5, 0x6d, 0xb5, 
        0xdf, 0xfb, 0x48, 0xd2, 
        0xb0, 0x60, 0xd0, 0xf5, 
        0xa7, 0x10, 0x96, 0xe0,
        // Major
        0x00, 0x00,
        // Minor
        0x00, 0x01,
        // TX power
        0xc5
    };
    writer.WriteBytes(dataArray);
    manufacturerData.Data = writer.DetachBuffer();
    // Add the manufacturer data to the advertisement publisher:
    publisher.Advertisement.ManufacturerData.Add(manufacturerData);
    publisher.Start();
