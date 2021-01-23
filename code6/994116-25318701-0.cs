        public enum RoomType
        {
            DoubleBB,
            SingleFullboard,
            SingleBB,
            DoubleFullboard,
            TwinBB,
            TwinFullboard
        }
    
        public class Room
        {
            public RoomType Type { get; set; }
            public int Price { get; set; }
        }
