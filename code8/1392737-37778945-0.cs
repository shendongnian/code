    [ImmutableObject(true)]
    public struct Vector3 : IEnumerable<float>, ICloneable
    {
        readonly float x, y, z;
        #region Definition
        public Vector3(float x, float y, float z)
        {
            this.x=x;
            this.y=y;
            this.z=z;
        }
        public Vector3(double x, double y, double z)
            : this((float)x, (float)y, (float)z) { }
        public Vector3(Vector3 other)
        {
            this.x=other.x;
            this.y=other.y;
            this.z=other.z;
        }
        public Vector3(string description)
            : this()
        {
            FromString(description);
        }
        public float X { get { return x; } }
        public float Y { get { return y; } }
        public float Z { get { return z; } }
        public float Magnitude { get { return Norm(); } }
        public float Norm() { return (float)Math.Sqrt(x*x+y*y+z*z); }
        public Vector3 Normalized() { var m=Norm(); if (m>0) return this/m; return this; }
        public static readonly Vector3 O=new Vector3(0, 0, 0);
        public static readonly Vector3 I=new Vector3(1, 0, 0);
        public static readonly Vector3 J=new Vector3(0, 1, 0);
        public static readonly Vector3 K=new Vector3(0, 0, 1);
        public static explicit operator Vector2(Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
        #endregion
        #region Math
        public Vector3 Add(Vector3 other, float scale=1)
        {
            return new Vector3(
                x+scale*other.x,
                y+scale*other.y,
                z+scale*other.z);
        }
        public Vector3 Scale(float scale)
        {
            return new Vector3(
                scale*x,
                scale*y,
                scale*z);
        }
        public Vector3 Multiply(Matrix3 rhs)
        {
            return new Vector3(
                X*rhs.A11+Y*rhs.A12+Z*rhs.A13,
                X*rhs.A21+Y*rhs.A22+Z*rhs.A23,
                X*rhs.A31+Y*rhs.A32+Z*rhs.A33);
        }
        public Vector3 Reciprocal(float numerator)
        {
            return new Vector3(numerator/x, numerator/y, numerator/z);
        }
        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return v1.x*v2.x+v1.y*v2.y+v1.z*v2.z;
        }
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                v1.y*v2.z-v1.z*v2.y,
                v1.z*v2.x-v1.x*v2.z,
                v1.x*v2.y-v1.y*v2.x);
        }
        public static float AngleBetween(Vector3 v1, Vector3 v2)
        {
            var cos=Dot(v1, v2);
            var sin=Cross(v1, v2).Norm();
            return (float)Math.Atan2(sin, cos);
        }
        public Vector3 AlongX() { return new Vector3(x, 0, 0); }
        public Vector3 AlongY() { return new Vector3(0, y, 0); }
        public Vector3 AlongZ() { return new Vector3(0, 0, z); }
        public Vector3 AlongXY() { return new Vector3(x, y, 0); }
        public Vector3 AlongYZ() { return new Vector3(0, y, z); }
        public Vector3 AlongZX() { return new Vector3(x, 0, z); }
        public Vector3 RotateAbout(Vector3 axis, float angle)
        {
            return Matrix3.RotateAbout(axis, angle)*this;
        }
        public Vector3 RotateAboutX(float angle)
        {
            float cos=(float)Math.Cos(angle), sin=(float)Math.Sin(angle);
            return new Vector3(
                x,
                y*cos-z*sin,
                y*sin+z*cos);
        }
        public Vector3 RotateAboutY(float angle)
        {
            float cos=(float)Math.Cos(angle), sin=(float)Math.Sin(angle);
            return new Vector3(
                x*cos+z*sin,
                y,
                -x*sin+z*cos);
        }
        public Vector3 RotateAboutZ(float angle)
        {
            float cos=(float)Math.Cos(angle), sin=(float)Math.Sin(angle);
            return new Vector3(
                x*cos-y*sin,
                x*sin+y*cos,
                z);
        }
        public Vector3 MirrorAboutXY() { return new Vector3(x, y, -z); }
        public Vector3 MirrorAboutXZ() { return new Vector3(x, -y, z); }
        public Vector3 MirrorAboutYZ() { return new Vector3(-x, y, z); }
        #endregion
        #region Operators
        public static Vector3 operator+(Vector3 lhs, Vector3 rhs) { return lhs.Add(rhs); }
        public static Vector3 operator-(Vector3 rhs) { return rhs.Scale(-1); }
        public static Vector3 operator-(Vector3 lhs, Vector3 rhs) { return lhs.Add(rhs, -1); }
        public static Vector3 operator*(float lhs, Vector3 rhs) { return rhs.Scale(lhs); }
        public static Vector3 operator*(Vector3 lhs, float rhs) { return lhs.Scale(rhs); }
        public static Vector3 operator/(Vector3 lhs, float rhs) { return lhs.Scale(1/rhs); }
        public static Vector3 operator/(float lhs, Vector3 rhs) { return rhs.Reciprocal(lhs); }
        public static float operator*(Vector3 lhs, Vector3 rhs) { return Dot(lhs, rhs); }
        public static Vector3 operator^(Vector3 lhs, Vector3 rhs) { return Cross(lhs, rhs); }
        public static Vector3 operator*(Vector3 lhs, Matrix3 rhs)
        {
            return lhs.Multiply(rhs);
        }
        #endregion
        #region ICloneable Members
        public Vector3 Clone() { return new Vector3(this); }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
        #region IEnumerable<float> Members
        public IEnumerator<float> GetEnumerator()
        {
            yield return x;
            yield return y;
            yield return z;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region IEquatable Members
        /// <summary>
        /// Equality overrides from <see cref="System.Object"/>
        /// </summary>
        /// <param name="obj">The object to compare this with</param>
        /// <returns>False if object is a different type, otherwise it calls <code>Equals(Vector3)</code></returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector3)
            {
                return Equals((Vector3)obj);
            }
            return false;
        }
        /// <summary>
        /// Checks for equality among <see cref="Vector3"/> classes
        /// </summary>
        /// <param name="other">The other <see cref="Vector3"/> to compare it to</param>
        /// <returns>True if equal</returns>
        public bool Equals(Vector3 other)
        {
            return x.Equals(other.x)
                &&y.Equals(other.y)
                &&z.Equals(other.z);
        }
        /// <summary>
        /// Calculates the hash code for the <see cref="Vector3"/>
        /// </summary>
        /// <returns>The int hash value</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((17*23+x.GetHashCode())*23+y.GetHashCode())*23+z.GetHashCode();
            }
        }
        #endregion
        #region IFormattable Members
        public override string ToString()
        {
            return ToString("G");
        }
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture.NumberFormat);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("({0},{1},{2})",
                x.ToString(format, formatProvider),
                y.ToString(format, formatProvider),
                z.ToString(format, formatProvider));
        }
        
        #endregion
        #region Triangles
        public static float TriangleArea(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 u=b-a, v=c-a;
            Vector3 k=Vector3.Cross(u, v);
            return k.Magnitude/2;
        }
        public static Vector3 TriangleNormal(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 u=b-a, v=c-a;
            return Vector3.Cross(u, v).Normalized();
        }
        
        #endregion
        #region IParsable Members
        public void FromString(string description)
        {
            // "(X,Y,Z)" => (X,Y,Z)
            description=description.Trim('(', ')');
            var parts=description.Split(',');
            if (parts.Length==3)
            {
                float new_x=0, new_y=0, new_z=0;
                if (!float.TryParse(parts[0].Trim(), out new_x))
                {
                    new_x=x;
                }
                if (!float.TryParse(parts[1].Trim(), out new_y))
                {
                    new_y=y;
                }
                if (!float.TryParse(parts[2].Trim(), out new_z))
                {
                    new_z=z;
                }
                this=new Vector3(new_x, new_y, new_z);
            }
        }
        public float[] ToArray()
        {
            return new float[] { X, Y, Z };
        }
        #endregion
    }
