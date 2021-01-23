    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace ObjectsWithCoordinates
    {
        public interface IObjWithCoordinates
        {
            int X { get; set; }
            int Y { get; set; }
        }
        public class MyObjWithCoordinates : IObjWithCoordinates
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string Name { get; set; }
        }
        public static class Extensions
        {
            public static T Find<T>(this IEnumerable<T> objects, int coordX, int coordY)
                where T : IObjWithCoordinates
            {
                var objList = objects as IEnumerable<IObjWithCoordinates>;
                if (objList == null)
                    throw new ArgumentException("objects must implement IObjWithCoordinates");
                return (T)objList.FirstOrDefault(o => o.X == coordX && o.Y == coordY);
            }
        }
        public static class Program
        {
            static void Main()
            {
                var obj1 = new MyObjWithCoordinates { X = 1, Y = 1, Name = "Name 1" };
                var obj2 = new MyObjWithCoordinates { X = 2, Y = 2, Name = "Name 2" };
                var obj3 = new MyObjWithCoordinates { X = 3, Y = 3, Name = "Name 3" };
                var coordObjList = new List<MyObjWithCoordinates> { obj1, obj2, obj3 };
                Console.WriteLine(coordObjList.Find(2, 2).Name);
                // Result should be "Name 2"
                Console.ReadLine();
            }
        }
    }
