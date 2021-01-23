    using System;
    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            var dc = new Decoder();
            dc.DecodeSkill();
            Debug.Assert(dc.TargetObjectId == 0m && dc.PositionX == 302 && dc.PositionY == 278 && dc.SkillId == 1115 && dc.SkillLevel == 0);
        }
    }
    class Decoder
    {
        public uint ObjectId = 1000001;
        public uint TargetObjectId = 2778236265;
        public ushort PositionX = 32409;
        public ushort PositionY = 16267;
        public ushort SkillId = 28399;
        public ushort SkillLevel = 8481;
        public void DecodeSkill()
        {
            SkillId = (ushort)(ExchangeShortBits((SkillId ^ ObjectId ^ 0x915d), 13) + 0x14be);
            SkillLevel = ((ushort)((byte)(SkillLevel) ^ 0x21));
            TargetObjectId = (ExchangeLongBits(TargetObjectId, 13) ^ ObjectId ^ 0x5f2d2463) + 0x8b90b51a;
            PositionX = (ushort)(ExchangeShortBits((PositionX ^ ObjectId ^ 0x2ed6), 15) + 0xdd12);
            PositionY = (ushort)(ExchangeShortBits((PositionY ^ ObjectId ^ 0xb99b), 11) + 0x76de);
        }
        private static uint ExchangeShortBits(uint data, int bits)
        {
            data &= 0xffff;
            return (data >> bits | data << (16 - bits)) & 65535;
        }
        public static int BitFold32(int lower16, int higher16)
        {
            return (lower16) | (higher16 << 16);
        }
        private static uint ExchangeLongBits(uint data, int bits)
        {
            return data >> bits | data << (32 - bits);
        }
    }
