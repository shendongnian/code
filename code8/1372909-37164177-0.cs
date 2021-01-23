    public static ushort oblicz_crc(byte[] buffer, int length)
    {
        unchecked
        {
            ushort crc = 0xffff;
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return (crc);
        }
    }
