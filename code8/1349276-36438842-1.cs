     public static void checkInput()
            {
                while (true)
                {
                    command = Console.ReadLine();
                    Console.WriteLine("Sending");
                    byte[] data = Encoding.ASCII.GetBytes(command);
                    foreach (Socket s in _clientSockets)
                    {
                        s.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), s);
                    }
                    command = null;
                }
            }
