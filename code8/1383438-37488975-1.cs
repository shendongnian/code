        public static bool IsBufferValidUnSafeXOR(byte[] buffer)
        {
            bool isValid = false;
            int byteLength = buffer.Length;
            int base64Length = byteLength >> 3;  // same as -- > (int)(byteLength / 8);
            int remainingBytes = byteLength - (base64Length << 3);
            ulong toggleMask = 0xFFFFFFFFFFFFFFFF;
            unsafe 
            {
                fixed (byte* pByteBuffer = buffer)
                {
                    ulong* pBuffer = (ulong*)pByteBuffer;
                    int index = 0;
                    while (index < base64Length)
                    {
                        if ((pBuffer[index] ^ toggleMask) > 0)
                        {
                            isValid = true;
                            break;
                        }
                        index++;
                    }
                }
            }
            // Check remainder of byte array
            if (!isValid)
            {
                int index = (base64Length << 3);
                while(index < byteLength)
                {
                    if (buffer[index] != 0xFF)
                    {
                        isValid = true;
                        break;
                    }
                    index++;
                }
            }
            return isValid;
        }
