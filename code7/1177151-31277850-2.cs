    // serialize 2 tokens
    var source = new CancellationTokenSource();
    var serialized = JsonConvert.SerializeObject(source.Token);
    var serialized2 = JsonConvert.SerializeObject(new CancellationTokenSource().Token);
    var handle = source.Token.WaitHandle.Handle;
    source.Dispose(); // releases source's handle
    
    // spin until the OS gives us back that same handle as
    // a file handle
    FileStream fileStream;
    while (true)
    {
    	fileStream = new FileStream(Path.GetTempFileName(), FileMode.OpenOrCreate);
    	if (fileStream.Handle == handle) { break; }
    }
    
    // deserialize both tokens, thus releasing the conflicting handle
    var deserialized = JsonConvert.DeserializeObject<CancellationToken>(serialized);
    var deserialized2 = JsonConvert.DeserializeObject<CancellationToken>(serialized2);
    
    GC.Collect();
    GC.WaitForPendingFinalizers();
    
    fileStream.WriteByte(1);
    fileStream.Flush(); // fails with IOException "The handle is invalid"
