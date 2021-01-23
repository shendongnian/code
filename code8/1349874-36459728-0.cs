        class Program {
        static void Main(string[] args) {
            // Create a stopwatch for performance testing
            var stopwatch = new Stopwatch();
            // Test content
            var data = GetTestingBytes();
            var ports = SerialPort.GetPortNames();
            using (SerialPort port = new SerialPort(ports[0], 115200, Parity.None, 8, StopBits.One)) {
                port.Open();
                // Looping Test
                stopwatch.Start();
                foreach (var item in data) {
                    port.BaseStream.WriteByte(item);
                }
                stopwatch.Stop();
                Console.WriteLine($"Loop Test: {stopwatch.Elapsed}");
                stopwatch.Start();
                port.Write(data, 0, data.Length);
                stopwatch.Stop();
                Console.WriteLine($"All At Once Test: {stopwatch.Elapsed}");
            }
            Console.Read();
        }
        static byte[] GetTestingBytes() {
            var str = String.Join(",", Enumerable.Range(0, 1000).Select(x => Guid.NewGuid()).ToArray());
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
