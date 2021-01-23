                int fileNameLen = 1;
                String content = String.Empty;
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;
                int bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    if (flag == 0)
                    {
                        fileNameLen = state.buffer[1];
                        //fileNameLen = BitConverter.ToInt32(state.buffer, 0);
                        string fileName = Encoding.UTF8.GetString(state.buffer, 2, fileNameLen);
                        receivedPath = @"C:\Users\Hankishan\Desktop\kayitlar\" + fileName;
                    flag++;
                }
                if (flag >= 1)
                {
                    BinaryWriter writer = new BinaryWriter(File.Open(receivedPath, FileMode.Append));
                    if (flag == 1)
                    {
                        writer.Write(state.buffer, 2 + fileNameLen, bytesRead - (2 + fileNameLen));
                        flag++;
                    }
                    else
                    {
                        if (flag == 2)
                        {
                            for (int i = 0; i < state.buffer.Length; i++)
                            {
                                if (i + 8 == 1023)
                                    break;
                                state.buffer[i] = state.buffer[i + 8];
                            }
                            writer.Write(state.buffer, 0, bytesRead);
                            flag++;
                        }else
                            writer.Write(state.buffer, 0, bytesRead);
                    }
                    writer.Close();
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
            else
            {
                Invoke(new MyDelegate(LabelWriter));
            }
            }
