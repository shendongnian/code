                List<byte> bytesReceived = new List<byte>();
                while (c.Available > 0 && c.Connected)
                {
                    byte[] nextByte = new byte[1];
                    c.Client.Receive(nextByte, 0, 1, SocketFlags.None);
                    bytesReceived.AddRange(nextByte);
                    if (nextByte[0] == _delimiter)
                    {
                        byte[] msg = _queuedMsg.ToArray();
                        _queuedMsg.Clear();
                        _parent.NotifyDelimiterMessageRx(this, c, msg);
                    } else
                    {
                        _queuedMsg.AddRange(nextByte);
                    }
                }
