    class myPacket {
      const byte topBit = 1 << 7;
      const byte lowerBits = ~topBit;
      public byte packed = 0;
      public int seqNumber {
        get { return value >> 7; }
        set { packed = value << 7 | packed & ~(1 << 7); } 
      }
      public int content {
        get { return value & ~(1 << 7); }
        set { packed = packed & (1 << 7) | value & ~(1 << 7); } 
      }
    }
