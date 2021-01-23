    using System;
    using System.Threading;
    using System.Threading.Tasks.Dataflow;
    namespace SensorDemo
    {
        public sealed class SensorAData
        {
            public int Data;
        }
        public sealed class SensorBData
        {
            public double Data;
        }
        public sealed class SensorData
        {
            public SensorAData SensorAData;
            public SensorBData SensorBData;
            public override string ToString()
            {
                return $"SensorAData = {SensorAData.Data}, SensorBData = {SensorBData.Data}";
            }
        }
        class Program
        {
            static void Main()
            {
                var input  = new TransformBlock<SensorAData, SensorData>(sensorAData => addSensorBData(sensorAData));
                var output = new ActionBlock<SensorData>(data => process(data));
                input.LinkTo(output, new DataflowLinkOptions { PropagateCompletion = true });
                for (int i = 0; i < 100; ++i)
                    input.Post(readSensorAData());
                input.Complete();
                Console.WriteLine("Completed.");
            }
            static SensorData addSensorBData(SensorAData sensorAData)
            {
                return new SensorData
                {
                    SensorAData = sensorAData,
                    SensorBData = readSensorBData()
                };
            }
            static SensorAData readSensorAData()
            {
                Console.WriteLine("Reading from Sensor A");
                Thread.Sleep(1000); // Simulate reading sensor A data taking some time.
                int value = Interlocked.Increment(ref sensorValue);
                Console.WriteLine("Read Sensor A value = " + value);
                return new SensorAData {Data = value}; 
            }
            static SensorBData readSensorBData()
            {
                Console.WriteLine("Reading from Sensor B");
                Thread.Sleep(100); // Simulate reading sensor B data being much quicker.
                int value = Interlocked.Increment(ref sensorValue);
                Console.WriteLine("Read Sensor B value = " + value);
                return new SensorBData {Data = value};
            }
            static void process(SensorData value)
            {
                Console.WriteLine("Processing sensor data: " + value);
            }
            static int sensorValue;
        }
    }
