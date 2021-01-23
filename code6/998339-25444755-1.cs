        public struct PointA
        {
            public int x;             // Offset 0, 4 bytes
                                      // Offset 4, 4 bytes of padding
            public string posorneg;   // Offset 8, 8 bytes
            public bool isvalid;      // Offset 16, 4 bytes
                                      // Offset 20, 4 bytes of padding
        }                             // Total: 24 bytes
        public struct PointB
        {
            public bool isvalid;      // Offset 0, 4 bytes
            public int x;             // Offset 4, 4 bytes
            public string posorneg;   // Offset 8, 8 bytes
        }                             // Total: 16 bytes
