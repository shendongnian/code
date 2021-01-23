     internal class Program
    {
        private static void Main(string[] args)
        {
            Task[] tasks = new Task[4];
            for (int i = 0; i < 4; i++)
            {
                //start task with current connection
                tasks[i] = new Task<byte[]>(GetData,i);
            }
            foreach (var task in tasks)
            {
                task.Start();
            }
            Task.WaitAll(tasks);
            Console.Read();
        }
        private static byte[] GetData(object index)
        {
            var i = (int) index;
            switch (i)
            {
                case 0:
                    //return plc.ReadBytes(DataType.DataBlock, 50, 0, 200);
                    Console.WriteLine(i);
                    return new byte[] { };
                case 1:
                //return plc.ReadBytes(DataType.DataBlock, 50, 200, 200);
                case 2:
                    Console.WriteLine(i);
                    return new byte[] { };
                //return plc.ReadBytes(DataType.DataBlock, 50, 500, 200);
                case 3:
                    Console.WriteLine(i);
                    return new byte[] { };
                //return plc.ReadBytes(DataType.DataBlock, 50, 700, 200);
                case 4:
                    //return plc.ReadBytes(DataType.DataBlock, 50, 900, 117);
                    Console.WriteLine(i);
                    return new byte[] { };
                default:
                    return null;
            }
        }
    }
