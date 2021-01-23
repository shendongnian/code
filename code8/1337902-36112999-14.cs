    MyWhateverBuffer<double> myBuffer = new MyWhateverBuffer<double>(100, 100, 100);
    var oneSlice = myBuffer.New();
    oneSlice[10, 10] = 3.5;
    oneSlice[50, 10] = 23.5;
    oneSlice[10, 20] = 43.5;
    myBuffer.Add(oneSlice);
    var anotherSlice = myBuffer.New();
    anotherSlice[10, 10] = 13.5;
    anotherSlice[50, 10] = 23.5;
    anotherSlice[10, 20] = 43.5;
    var result = myBuffer.Add(anotherSlice);
    if(!result)
    {
        // the buffer was full..
    }
    // Read the results from the buffer.
    foreach(var slice in myBuffer.ReadAll())
    {
        Trace.WriteLine(slice[10, 10]);
    }
