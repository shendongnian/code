    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StringToMapPoint
    {
        class Program
        {
            static void Main(string[] args)
            {
                string mapPointStr = "45,5235234096284 112,013574120648";
                MapPoint mp = mapPointStr.ToMapPoint();
                Console.WriteLine(mp.ToString());
            }
        }
    
        public class MapPoint
        {
            public double X { get; set; }
            public double Y { get; set; }
    
            public override string ToString()
            {
                return "X: " + X + " Y: " + Y;
            }
        }
    
        public static class MapPointHelper
        {
            public static MapPoint ToMapPoint(this string str)
            {
                var split = str.Split(' ');
                return new MapPoint() { X = Double.Parse(split[0]), Y = Double.Parse(split[1]) };
            }
        }
    }
