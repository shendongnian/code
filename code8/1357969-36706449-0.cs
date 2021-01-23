    using System;
    using System.IO;
    using System.Threading;
    using System.Security.Cryptography;
    namespace Stack
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var cancellationTokenSource = new CancellationTokenSource())
                {
                    var thread = new Thread(() =>
                    {
                        try
                        {
                            var hash = CalcHash("D:/Image.iso", cancellationTokenSource.Token);
                            Console.WriteLine($"Done: hash is {BitConverter.ToString(hash)}");
                        }
                        catch (OperationCanceledException)
                        {
                            Console.WriteLine("Canceled :(");
                        }
                    });
                    // Start background thread
                    thread.Start();
                    Console.WriteLine("Working, press any key to exit");
                    Console.ReadLine();
                    cancellationTokenSource.Cancel();
                }
                Console.WriteLine("Finished");
                Console.ReadLine();
            }
            static byte[] CalcHash(string path, CancellationToken ct)
            {
                using (var stream = File.OpenRead(path))
                using (var md5 = MD5.Create())
                {
                    const int blockSize = 1024 * 1024 * 4;
                    var buffer = new byte[blockSize];
                    long offset = 0;
                    while (true)
                    {
                        ct.ThrowIfCancellationRequested();
                        var read = stream.Read(buffer, 0, blockSize);
                        if (stream.Position == stream.Length)
                        {
                            md5.TransformFinalBlock(buffer, 0, read);
                            break;
                        }
                        offset += md5.TransformBlock(buffer, 0, buffer.Length, buffer, 0);
                        Console.WriteLine($"Processed {offset * 1.0 / 1024 / 1024} MB so far");
                    }
                    return md5.Hash;
                }
            }
        }
    }
