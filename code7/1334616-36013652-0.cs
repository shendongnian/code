            using (mySocket) { //whatever you are using, maybe a TcpClient
            while (true)
            {
                    byte[] data = new byte[8192];
                    int recvCount = await _stream.ReadAsync(data, 0, data.Length);
                    if (recvCount == 0) break;
                    Array.Resize(ref data, recvCount);
                    Console.WriteLine(">>{0}<<", Encoding.UTF8.GetString(data));
            }
            Shutdown();
            }
