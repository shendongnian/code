    uint sum = 0;
    uint zeroOffset = 0x30; // ASCII '0'
    
    byte[] inputData = Encoding.ASCII.GetBytes(recordCheckSum);
    
    for (int i = 0; i < inputData.Length; i++)
    {
        int product = inputData[i] & 0x7F; // Take the low 7 bits from the record.
        product *= i + 1; // Multiply by the 1 based position.
        sum += (uint)product; // Add the product to the running sum.
    }
    
    byte[] result = new byte[8];
    for (int i = 0; i < 8; i++) // if the checksum is reversed, make this:
                                // for (int i = 7; i >=0; i--) 
    {
        uint current = (uint)(sum & 0x0f); // take the lowest 4 bits.
        current += zeroOffset; // Add '0'
        result[i] = (byte)current;
        sum = sum >> 4; // Right shift the bottom 4 bits off.
    }
    
    string checksum = Encoding.ASCII.GetString(result);
