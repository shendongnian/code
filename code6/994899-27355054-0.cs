    var buffer = new BufferBlock<object>();
    buffer.Post(null);
    IList<object> items;
    buffer.TryReceiveAll(out items);
    var outputAvailableAsync = buffer.OutputAvailableAsync();
    buffer.Post(null);
    await outputAvailableAsync; // Never completes
