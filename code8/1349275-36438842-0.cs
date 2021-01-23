    if (command != null)
                        {
                            byte[] data = Encoding.ASCII.GetBytes(command);
                            foreach (Socket s in _clientSockets)
                            {
                                s.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), s);
                            }
                        }
                        command = null;
