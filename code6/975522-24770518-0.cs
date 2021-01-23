    public struct Vec3
    {
        private float[] MyVals;
        public float this[int a]
        {
            get { return MyVals[a]; }
            set { MyVals[a] = value; }
        }
        public static implicit operator float[](Vec3 vec)
        {
            return vec.MyVals;
        }
         public static implicit operator Vec3(float[] values)
         {
             var v = new Vec3();
             v.MyVals = values;
             return v;
         }
    }
     public static Vec3 SuperVector = new[] { 2f, 5f, 6f };
