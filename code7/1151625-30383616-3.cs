    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication1 {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            var source = new object();
            // implicit conversion works great!!
            // therefore I can achieve the goal of passing the fully-typed read-write dataseries
            // into objects that just want simple read-only data
            var inputSeries = new DataSeries<SimpleDataPoint>(source);
            // passing inputSeries into the constructor involves an implicit
            // conversion to IReadOnlyDataSeries<IDataPoint>
            var processor = new DataProcessor(inputSeries);
            Console.ReadKey();
        }
        public class DataProcessor {
            IReadOnlyDataSeries<IDataPoint> InputSeries;
            DataSeries<SimpleDataPoint> OutputSeries;
            public DataProcessor(IReadOnlyDataSeries<IDataPoint> inputSeries) {
                InputSeries = inputSeries;
                OutputSeries = new DataSeries<SimpleDataPoint>(this);
            }
        }
    }
    public interface IDataPoint {
        int Index { get; set; }
        double Value { get; set; }
        DateTime TimeStampLocal { get; set; }
        IDataPoint Clone();
    }
    public sealed class SimpleDataPoint : IDataPoint {
        public int Index { get; set; }
        public double Value { get; set; }
        public DateTime TimeStampLocal { get; set; }
        public IDataPoint Clone() {
            return new SimpleDataPoint {
                Index = Index,
                Value = Value,
                TimeStampLocal = TimeStampLocal,
            };
        }
    }
    // here's the covariant, read-only part of the interface declaration
    public interface IReadOnlyDataSeries<out TDataPoint> where TDataPoint : class, IDataPoint {
        object Source { get; }
        int Count { get; }
        double GetValue(int index);
        DateTime GetTimeStampLocal(int index);
        TDataPoint GetDataPoint(int index);
        TDataPoint GetLastDataPoint();
    }
    // add a few bits to the read-write fully-typed interface, breaking covariance,
    // but being able to implicitly cast to the covariant readonly version when needed
    public interface IDataSeries<TDataPoint> : IReadOnlyDataSeries<TDataPoint> where TDataPoint : class, IDataPoint {
        void Add(TDataPoint dataPoint);
        IDataSeries<TDataPoint> Branch(object source);
    }
    public class DataSeries<TDataPoint> : IDataSeries<TDataPoint> where TDataPoint : class, IDataPoint {
        readonly List<TDataPoint> _data = new List<TDataPoint>();
        public object Source {
            get;
            private set;
        }
        public DataSeries(object source) {
            Source = source;
        }
        public int Count {
            get { return _data.Count; }
        }
        public TDataPoint GetDataPoint(int index) {
            return _data[index];
        }
        public TDataPoint GetLastDataPoint() {
            return _data[_data.Count - 1];
        }
        public DateTime GetTimeStampLocal(int index) {
            return _data[index].TimeStampLocal;
        }
        public double GetValue(int index) {
            return _data[index].Value;
        }
        public void Add(TDataPoint dataPoint) {
            _data.Add(dataPoint);
        }
        public IDataSeries<TDataPoint> Branch(object source) {
            throw new NotImplementedException();
        }
    }
    }
