        while(0 != (read = sourceStream.Read(bufferRead, 0, sliceBytes)))
    {
       tasks[taskCounter] = Task.Factory.StartNew(() => 
         CompressStreamP(bufferRead, read, taskCounter, ref listOfMemStream, eventSignal)); // Line 1
       eventSignal.WaitOne(-1);           // Line 2
       taskCounter++;                     // Line 3
       bufferRead = new byte[sliceBytes]; // Line 4
    }
    
    Task.WaitAll(tasks);                  // Line 6
