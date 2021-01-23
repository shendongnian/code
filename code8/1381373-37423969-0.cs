    private Task pollDeviceRegisters(ICollection<ProfileElementType> collection)
    {
        var blockingCollection = new BlockingCollection<Register>();
        // This starts three threads to start reading the serial ports (arbitrary number of threads to start you will need to see what is optimal)
        var pollingTask = Task.WhenAll(ReadSerialPort(blockingCollection),
            ReadSerialPort(blockingCollection),
            ReadSerialPort(blockingCollection))
            .ContinueWith(task =>
            {
                blockingCollection.Dispose();
                return task;
            });
        BuildDeviceRegisters(collection, blockingCollection);
        return pollingTask;
    }
    // Creates a new thread and waits on the blocking collection
    private Task ReadSerialPort(BlockingCollection<Register> collection)
    {
        return Task.Run(() =>
        {
            foreach (var reg in collection.GetConsumingEnumerable())
            {
                // Get this register' value from outer device via serial port using MODBUS RTU protocol.
                var aRes = ReadHoldingRegisters(deviceAddress, reg.Number, 1);
                reg.CurrentValue = aRes[0].ToString("X");
            }
        });
    }
    // flattens the hierarchical data
    private static void BuildDeviceRegisters(ICollection<ProfileElementType> collection,
        BlockingCollection<Register> blockingCollection)
    {
        if (collection != null)
        {
            //using a stack instead of recursion (could switch to ConcurrentStack and use Parallel.ForEach() but wouldn't mess with it if not bottle neck)
            var stack = new Stack<ICollection<ProfileElementType>>(new[] {collection});
            while (stack.Count > 0)
            {
                var element = stack.Pop();
                foreach (var item in element)
                {
                    var group = item as Group;
                    if (group != null)
                    {
                        // push the tree branch on to the stack
                        stack.Push(group.ChildProfileElenents);
                    }
                    else
                    {
                        blockingCollection.Add((Register)item);
                    }
                }
            }
        }
        // Mark we are done adding to the collection
        blockingCollection.CompleteAdding();
    }
