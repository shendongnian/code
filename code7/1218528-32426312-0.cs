    public static BigInteger ParseBinary( string bitstring )
    {
        byte[] raw;
        // Calculate the total number of bytes we'll need to store the 
        // result. Remember that 10 bits / 8 = 1.25 bytes --> 2 bytes. 
        int rawLength;
        int rawPosition;
        int bitStart = 0;
        rawLength = (int)Math.Ceiling( bitstring.Length / 8.0 );
        // Force BigInteger to interpret our array as an unsigned value.
        raw = new byte[rawLength + 1];
        rawPosition = rawLength - 1;
        // Lets assume we have the string 10 1111 0101
        // Lets parse that odd chunk '10' first, and then we can parse the rest on nice
        // and simple 8-bit bounderies. Keep in mind that the '10' chunk occurs at indicies 
        // 0 and 1, but represent our highest order bits.
        if ( rawLength * 8 != bitstring.Length )
        {
            int leftoverBits = bitstring.Length % 8;
            raw[rawPosition] = ParseChunk( bitstring, 0, leftoverBits );
            rawPosition--;
            bitStart += leftoverBits;
        }
        // Parse all of the 8-bit chunks that we can.
        for ( int i = bitStart; i < bitstring.Length; i += 8 )
        {
            raw[rawPosition] = ParseChunk( bitstring, i, 8 );
            rawPosition--;
        }
        return new BigInteger( raw );
    }
    private static byte ParseChunk( string bitstring, int startPosition, int run )
    {
        byte result = 0;
        byte temp;
            
        for ( int i = 0; i < run; i++ )
        {
            // Abuse the unicode ordering of characters.
            temp = (byte)(bitstring[startPosition + i] - '0');
            result |= (byte)(temp << run - i - 1);
        }
        return result;
    }
