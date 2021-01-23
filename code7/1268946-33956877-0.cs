    var proc = Process.GetProcessesByName("myapp.exe").FirstOrDefault();
    using (var target = DataTarget.AttachToProcess(proc.Id, 1000))
    {
        var runtime = target.ClrVersions[0].CreateRuntime();
        var heap = runtime.GetHeap();
        foreach (var obj in heap.EnumerateObjectAddresses())
        {
            var type = heap.GetObjectType(obj);
            if (type.Name == "System.String")
            {
                var value = (string)type.GetValue(obj);
                // Write value to disk or something.
            }
        }
    }
