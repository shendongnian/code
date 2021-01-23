    HidOutputReport outputReport = device.CreateOutputReport();
    
    byte[] bytesToCopy = new byte[textBox.Text.Length];
    bytesToCopy = System.Text.Encoding.ASCII.GetBytes(textBox.Text);
    
    //I used a similiar one (equals the customHID sample)
    //DataWriter dataWriter = new DataWriter();
    //dataWriter.WriteBytes(bytesToCopy);
    
    // This line is to show for you that the problem isn't the bytesToCopy but the your filling vector (Value does not fall within the expected range).
    var x=bytesToCopy.AsBuffer();
    
    //Here, You take the bytes and put in report data. If outputReport.Data.Capacity was different of your bytesToCopy.Length the app throws a exception.*
    outputReport.Data = x;
    
    //outputReport.Data = CryptographicBuffer.CreateFromByteArray(bytesToCopy);
    
    //WindowsRuntimeBufferExtensions.CopyTo(bytesToCopy, 0, outputReport.Data, 0, bytesToCopy.Length);
    uint bytesWritten = await proscannerSystem_device.SendOutputReportAsync(outputReport);
