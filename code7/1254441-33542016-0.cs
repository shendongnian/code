    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
    using static System.Console;
    
    
    namespace CopyAsync
    {
    
        [TestClass]
        public class UnitTest
        {
            private int _bufferSize = 4096;
    
            [TestMethod]
            public void CopyFileAsyncSouldCopyFile()
            {
                _bufferSize = 100;
    
                const string source = @"..\..\UnitTest.cs";
                var destination = Path.GetRandomFileName();
    
                WriteLine($"Start...");
    
                var task = FileCopyAsync(source, destination, action: total => WriteLine($"Copying... {total}"));
    
                var bytes = task.Result;
    
                WriteLine($"Bytes copied... {bytes}");
    
                IsTrue(File.Exists(destination));
                AreEqual((new FileInfo(source)).Length, bytes);
    
                File.Delete(destination);
            }
    
            [TestMethod]
            public void CopyFileAsyncCancelledSouldCancelCopyFile()
            {
                _bufferSize = 100;
    
                const string source = @"..\..\UnitTest.cs";
                var destination = Path.GetRandomFileName();
    
                var cts = new CancellationTokenSource();
    
                WriteLine($"Start...");
    
                var task = FileCopyAsync(source, destination,
                    token: cts.Token,
                    action: total =>
                    {
                        WriteLine($"Copying... {total}");
    
                        if (total < 2000)
                            return;
    
                        cts.Cancel();
    
                        WriteLine($"Canceled... at {total}");
                    });
    
                try
                {
                    task.Wait();               // exception WILL BE thrown here... PERFECT!!!!
                }
                catch (AggregateException ex) when (ex.InnerException.GetType() == typeof(TaskCanceledException))
                {
                    WriteLine($"TaskCanceledException...");
                    File.Delete(destination);
                }
            }
    
            [TestMethod]
            public void CopyFileAsyncNetworkErrorShouldFail()
            {
                _bufferSize = 4096;
    
                const string source = @"\\server\sharedfolder\bigfile.iso"; // to test close network connection while copying...
                var destination = Path.GetRandomFileName();
    
                WriteLine($"Start...");
                var task = FileCopyAsync(source, destination, action: total => WriteLine($"Copying... {total}"));
    
                try
                {
                    task.Wait();                  // exception WILL BE thrown here... PERFECT!!!! more than PERFECT
                }
                catch (AggregateException ex) when (ex.InnerException.GetType() == typeof(IOException))
                {
                    WriteLine($"IOException...");
                    File.Delete(destination);
                }
            }
    
    //      ##########################
    
            public async Task<int> FileCopyAsync(string sourceFileName, string destFileName, bool overwrite = false, CancellationToken token = default(CancellationToken), Action<long> action = null)
            {
                if (string.Equals(sourceFileName, destFileName, StringComparison.InvariantCultureIgnoreCase))
                    throw new IOException($"Source {sourceFileName} and destination {destFileName} are the same");
    
                using (var sourceStream = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read, _bufferSize, true))
                using (var destStream = new FileStream(destFileName, FileMode.Create, FileAccess.Write, FileShare.None, _bufferSize, true))
                {
                    var bytesCopied = await StreamCopyAsync(sourceStream, destStream, token, action);
    
                    if (bytesCopied != (new FileInfo(sourceFileName)).Length)
                        throw new IOException($"Source {sourceFileName} and destination {destFileName} don't match");
    
                    return bytesCopied;
                }
            }
    
            public async Task<int> StreamCopyAsync(Stream sourceStream, Stream destStream, CancellationToken token = default(CancellationToken), Action<long> action = null)
            {
                if (Equals(sourceStream, destStream))
                    throw new ApplicationException("Source and destination are the same");
    
                using (var reg = token.Register(() => Close(sourceStream, destStream))) // disposes registration for token cancellation callback
                {
                    int bytes;
                    var bytesCopied = 0;
                    var buffer = new byte[_bufferSize];
    
                    while ((bytes = await sourceStream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                    {
                        if (token.IsCancellationRequested)
                            break;
    
                        await destStream.WriteAsync(buffer, 0, bytes, token);
    
                        bytesCopied += bytes;
    
                        action?.Invoke(bytesCopied);
                    }
    
                    return bytesCopied;
                }
            }
    
            private static void Close(Stream source, Stream destination) // fires on token cancellation
            {
                source.Close();
                destination.Close();
            }
        }
    }
