    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                var ds = (IDataSeries<IDataPoint>)new DataSeries<SimpleDataPoint>();
                Console.ReadKey();
            }
        }
        public interface IDataPoint { }
        public sealed class SimpleDataPoint : IDataPoint { }
        public interface IDataSeries<out TDataPoint> where TDataPoint : class, IDataPoint { }
        public class DataSeries<TDataPoint> : IDataSeries<TDataPoint> where TDataPoint : class, IDataPoint { }
    }
