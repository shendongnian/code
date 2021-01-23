        class RFIDReader : IDisposable
        {
            public void StartStreaming()
            {
                if (RFID_ConnectSerialPort(mAPIHandle, 4, 115200) == 0 || RFID_ConnectAutoUSB(mAPIHandle) == 0)
                {
                    RFID_StartInventoryStreaming(
                        (value, antenna) => {
                            mAntennas[antenna].Add(value);
                        });
                }
            }
    /////// MORE FUNCTIONS
        }
