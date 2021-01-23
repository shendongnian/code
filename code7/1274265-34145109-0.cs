                int byteCount;
                using (var serverSocket = server.AcceptSocket())
                {
                    byteCount = serverSocket.Send(bytes);
                }
                Console.WriteLine("server send: " + byteCount);
    (Disposing of disposables as soon as you are done with them is a good idea always.)
