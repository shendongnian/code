    var BYTE_NUM = 64 as UInt32; //Read this many bytes
    IInputStream input = socket.InputStream;
    IOutputStream output = socket.OutputStream;
    var inputBuffer = new Buffer();
    var operation = input.ReadAsync(inputBuffer, BYTE_NUM, InputStreamOptions.none);
    while (!operation.Completed) Thread.Sleep(200);
    inputBuffer = operation.GetResults();
    var resultReader = DataReader.FromBuffer(inputBuffer);
    byte[] result = new byte[BYTE_NUM];
    resultReader.ReadBytes(result);
    resultReader.Dispose();
    //Do something with the bytes retrieved. If the Bluetooth device has an api, it will likely specify what bytes will be sent from the device
    //Now time to give some data to the device
    byte[] outputData = Encoding.ASCII.GetBytes("Hello, Bluetooth Device. Here's some data! LALALALALA");
    IBuffer outputBuffer = outputData.AsBuffer(); //Neat method, remember to include System.Runtime.InteropServices.WindowsRuntime
    operation = output.WriteAsync(outputBuffer);
    while (!operation.Completed) Thread.Sleep(200);
    await output.FlushAsync(); //Now the data has really been written
