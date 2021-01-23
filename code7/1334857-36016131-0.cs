    public short CalcCrc16(char str)
    {
        short crc = 0;
        int i;
        unchecked
        {
            for(i = 0; i < char.GetNumericValue(str); i++)
            {
                bool crcCheck = ((crc << 1) ^ (str + i) ^ ((crc & 0x8000)) != 0;
                crc = crcCheck ? 0x1021 : 0);
            }
            return (crc & 0xFFFF);
        }
    }
