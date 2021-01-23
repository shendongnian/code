    using System;
    using System.Threading;
    using System.Threading.Tasks;
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
                var sensorADataSource = new TransformBlock<SensorAData, SensorData>(
                    sensorAData => addSensorBData(sensorAData), 
                    dataflowOptions());
                var combinedSensorProcessor = new ActionBlock<SensorData>(
                    data => process(data), 
                    dataflowOptions());
                sensorADataSource.LinkTo(combinedSensorProcessor, new DataflowLinkOptions { PropagateCompletion = true });
                // Create a cancellation source that will cancel after a few seconds.
                var cancellationSource = new CancellationTokenSource(delay:TimeSpan.FromSeconds(20));
                Task.Run(() => continuouslyReadFromSensorA(sensorADataSource, cancellationSource.Token));
                Console.WriteLine("Started reading from SensorA");
                sensorADataSource.Completion.Wait(); // Wait for reading from SensorA to complete.
                Console.WriteLine("Completed reading from SensorA.");
                combinedSensorProcessor.Completion.Wait();
                Console.WriteLine("Completed processing of combined sensor data.");   
            }
            static async Task continuouslyReadFromSensorA(TransformBlock<SensorAData, SensorData> queue, CancellationToken cancellation)
            {
                while (!cancellation.IsCancellationRequested)
                    await queue.SendAsync(readSensorAData());
                queue.Complete();
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
                Thread.Sleep(1000); // Simulate slow processing of combined sensor values.
            }
            static ExecutionDataflowBlockOptions dataflowOptions()
            {
                return new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = 1,
                    BoundedCapacity        = 1
                };
            }
            static int sensorValue;
        }
    }
