    public static unsafe void CopyUnsafe(byte[] sourceArray, int sourceIndex, byte[] destinationArray, int destinationIndex, int length)
    {
        const int procInstrSize = 4; 
        fixed (byte* pDst = &destinationArray[destinationIndex])
        {
            fixed (byte* source = &sourceArray[sourceIndex])
            {
                byte* ps = source;
                byte* pd = pDst;
                // Loop over the count in blocks of 4 bytes, copying an integer (4 bytes) at a time:
                for (int i = 0; i < length / procInstrSize; i++)
                {
                    *((int*) pd) = *((int*) ps);
                    pd += procInstrSize;
                    ps += procInstrSize;
                }
                // Complete the copy by moving any bytes that weren't moved in blocks of 4:
                for (int i = 0; i < length % procInstrSize; i++)
                {
                    *pd = *ps;
                    pd++;
                    ps++;
                }
            }
        }
    }
