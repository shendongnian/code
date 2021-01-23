    public struct Vector2
    {
        public double x, y;
        public Vector2(double x, double y)
        {
            this.x = x; this.y = y;
        }
        #region linear algebra
        public static Vector2 operator +(Vector2 first, Vector2 second)
        {
            return new Vector2(first.x + second.x, first.y + second.y);
        }
        #endregion
        #region conversions to/from higher dimensions
        public static implicit operator Vector3(Vector2 v2)
        {
            return new Vector3(v2.x, v2.y, 0);
        }
        public static implicit operator Vector4(Vector2 v2)
        {
            return new Vector4(v2.x, v2.y, 0, 0);
        }
        public static explicit operator Vector2(Vector3 v3)
        {
            return new Vector2(v3.x, v3.y);
        }
        public static explicit operator Vector2(Vector4 v4)
        {
            return new Vector2(v4.x, v4.y);
        }
        #endregion
    }
    public struct Vector3
    {
        public double x, y, z;
        public Vector3(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }
        #region linear algebra
        public static Vector3 operator +(Vector3 first, Vector3 second)
        {
            return new Vector3(first.x + second.x, first.y + second.y, first.z + second.z);
        }
        #endregion
        #region conversions to/from higher dimensions
        public static implicit operator Vector4(Vector3 v3)
        {
            return new Vector4(v3.x, v3.y, v3.z, 0);
        }
        public static explicit operator Vector3(Vector4 v4)
        {
            return new Vector3(v4.x, v4.y, v4.z);
        }
        #endregion
    }
    public struct Vector4
    {
        public double x, y, z, w;
        public Vector4(double x, double y, double z, double w)
        {
            this.x = x; this.y = y; this.z = z; this.w = w;
        }
        #region linear algebra
        public static Vector4 operator +(Vector4 first, Vector4 second)
        {
            return new Vector4(first.x + second.x, first.y + second.y, first.z + second.z, first.w + second.w);
        }
        #endregion
    }
