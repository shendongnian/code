    try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                }                                                       // Add to fix
                                                                        // Add to fix
                int bytesRemain = state.workSocket.Available;           // Add to fix
                if (bytesRemain>0)                                      // Add to fix
                {                                                       // Add to fix
                    //  Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length >= 1)                 //<-- Fixed from>1 to >=1
                        response = state.sb.ToString();
                    else
                        response = ""; //OR null;
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                }
            }
