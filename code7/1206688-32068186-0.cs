    class Vector3D
    {
        public float X;
        public float Y;
        public float Z;
    
        public static float GetDistance(Vector3D va, Vector3D vb)
        {
            if ((va == null) || (vb == null))
            {
                Console.WriteLine("Params are null.");
                return 0f;
            }
            
            return Math.Sqrt((va.X * va.X  - vb.X * vb.X) + (va.Y * va.Y  - vb.Y * vb.Y) + (va.Z * va.Z  - vb.Z * vb.Z));
        }
    }
