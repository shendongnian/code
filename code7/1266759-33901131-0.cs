    public int DoShift()
    {
        int newBit = 1 << (length - 1); // you can save it as class member
        int result = Contents & 1;
        int feedback = Contents & tapSequence;
        Contents >>= 1;
        while(feedback != 0) {
          feedback &= feedback - 1;
          Contents ^= newBit;
        }
        return result;
    }
