    private Task ConsumeAsync()
    {
        // as long as there is something to process: fetch it and process it
        while (await bufferBlock.OutputAvailableAsync())
        {
            T nextToProcess = await bufferBlock.ReceiveAsync();
            // use WriteAsync to send to the serial port:
            await WriteAsync(nextToProcess);
        }
        // if here: no more data to process. Return
    }
