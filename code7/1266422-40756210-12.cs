    public struct Vertex
    {        
        public Vector2<float> Pos;        
        public Vector2<float> Texcoord;        
        public Vector4<byte> Color;
    }
    public struct Vector2<T>
    {
        public T x, y;
    }
    public struct Vector3<T>
    {
        public T x, y, z;
    }
    public struct Vector4<T>
    {
        public T x, y, z, w;
    }
