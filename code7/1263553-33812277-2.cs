    public Interleaver(int dimensions, int bitDepth)
    {
        Dimensions = dimensions;
        BitDepth = bitDepth;
        Bits = Dimensions * BitDepth;
        BytesNeeded = Bits >> 3; // If we have 7 bits, 7 >> 3 is zero. We will add one byte to this to handle the extra bits.
        PrecomputedIndices = new Indices[Dimensions * BitDepth];
        for (var iBit = 0; iBit < Bits; iBit++)
        {
            PrecomputedIndices[iBit] = new Indices(
                iBit % Dimensions,
                (byte)(iBit / Dimensions),
                (short) (iBit >> 3),
                (byte)(iBit & 0x7)
            );
        }
        Comparison<Indices> sortByTargetByteAndBit = (a, b) =>
        {
            if (a.iToByteVector < b.iToByteVector) return -1;
            if (a.iToByteVector > b.iToByteVector) return 1;
            if (a.iToByteBit < b.iToByteBit) return -1;
            if (a.iToByteBit > b.iToByteBit) return 1;
            return 0;
        };
        Array.Sort(PrecomputedIndices, sortByTargetByteAndBit);
    }
