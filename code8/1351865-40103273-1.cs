    static void testVec() 
    {
       List<Vector3D> vec = new List<Vector3D>();
       vec.Add(new Vector3D(0, 1, 0));
       vec.Add(new Vector3D(0, -1, 0));
       vec.Add(new Vector3D(0, 2, 0));
       double min_y = vec.Min(x => x.Y);
    }
