    struct Indices
    {
        /// <summary>
        /// Index into source vector of source uint to read.
        /// </summary>
        public readonly int iFromUintVector;
        /// <summary>
        /// Index into target vector of target byte to write.
        /// </summary>
        public readonly short iToByteVector;
        /// <summary>
        /// Index into source uint of source bit to read.
        /// </summary>
        public readonly byte iFromUintBit;
        /// <summary>
        /// Index into target byte of target bit to write.
        /// </summary>
        public readonly byte iToByteBit;
        public Indices(int fromUintVector, byte fromUintBit, short toByteVector, byte toByteBit)
        {
            iFromUintVector = fromUintVector;
            iFromUintBit = fromUintBit;
            iToByteVector = toByteVector;
            iToByteBit = toByteBit;
        }
    }
