    public class RawDataService : IReceiveData
    {
    public void UploadFile(string fileName, Stream fileContents)
    {
        byte[] buffer = new byte[10000];
        int bytesRead, totalBytesRead = 0;
        do
        {
            bytesRead = fileContents.Read(buffer, 0, buffer.Length);
            totalBytesRead += bytesRead;
        } while (bytesRead > 0);
        Console.WriteLine("Service: Received file {0} with {1} bytes", fileName, totalBytesRead);
    }
