        private static void BytesToSingle()
        {
            // Remember that  0x42c80000 has the 0x42 at the highest byte, 00 at the lowest byte.
            byte[] snmpData = new byte[] { 0x00, 0x00, 0xC8, 0x42 };
            single floatVal = BitConverter.ToSingle( snmpData, 0 );
            // Prints "100.0".
            Console.WriteLine( floatVal );
        }
