    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Vector3> vector3 = new List<Vector3>();
                Vector3 myTransform = new Vector3(33, 12, 0);
                vector3.Add(myTransform);
                Vector3 results = vector3.Find(x => x == myTransform);
            }
         }
        public class Vector3 : IEqualityComparer<Vector3>
        {
            public int x { get; set; }
            public int y { get; set; }
            public int z { get; set; }
            public Vector3(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public Boolean Equals(Vector3 a, Vector3 b)
            {
                return a == b;
            }
            public int GetHashCode(Vector3 vector3)
            {
                return (vector3.x.ToString() + "^" + vector3.y.ToString() + "^" + vector3.z.ToString()).GetHashCode();
            }
        }
     
     
    }
