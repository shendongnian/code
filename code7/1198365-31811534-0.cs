    class PointClass {
        public int X { get; }
        public int Y { get; }
        public PointClass(int x, int y) { X = x; Y = y; }
    }
    struct PointStruct {
        public int X { get; }
        public int Y { get; }
        public PointStruct(int x, int y) { X = x; Y = y; }
    }
    ...
    PointClass pc = ...
    PointStruct? ps = ...
    int? x = pc?.X;
    int? y = ps?.Y;
