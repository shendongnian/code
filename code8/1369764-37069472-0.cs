         public static BitArray ToBigEndian(byte[] byteArray)
         {
            if (byteArray == null)
            {
               return null;
            }
            BitArray bitArray;
            if (BitConverter.IsLittleEndian)
            {
               bitArray = new BitArray(byteArray.Length * 8);
               int offset = 0;
               foreach (var byteValue in byteArray)
               {
                  for (int index = 0; index < 8; index++)
                  {
                     bool isBitSet = (byteValue & (0x80 >> index)) > 0;
                     bitArray.Set(offset + index, isBitSet);
                  }
                  offset += 8;
               }
            }
            else
            {
               bitArray = new BitArray(byteArray);
            }
            return bitArray;
         }
         public static byte[] FromBigEndian(BitArray bitArray)
         {
            if (bitArray == null || bitArray.Length <= 0 || bitArray.Length % 8 > 0)
            {
               return null;
            }
            int countOfBytes = bitArray.Length / 8;
            byte[] byteArray = new byte[countOfBytes];
            if (BitConverter.IsLittleEndian)
            {
               for (int index = 0; index < bitArray.Length; index += 8)
               {
                  byte value = 0;
                  int dataIndex = index / 8;
                  for (int i = 0; i < 8; i++)
                  {
                     bool isBitSet = bitArray[index + i];
                     value |= (byte)(((isBitSet ? 0x01 : 0) << (7 - i)));
                  }
                  byteArray[dataIndex] = value;
               }
            }
            else
            {
               bitArray.CopyTo(byteArray, 0);
            }
            return byteArray;
         }
