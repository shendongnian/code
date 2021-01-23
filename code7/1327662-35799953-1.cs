    private static void ReceiveCallback(IAsyncResult ar)
    {     
        try
        {
            Console.WriteLine("Receieve Call Back Invoked");
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;
            // Read data from the remote device.
            int bytesRead = client.EndReceive(ar);
            Console.WriteLine("Receieve End Receieve");
            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                Console.WriteLine("Read : " + bytesRead.ToString());
                // Get the rest of the data.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
                Console.WriteLine("Begin Receieve completed");
            }
            else
            {
                // All the data has arrived; put it in response.
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                }
                Console.WriteLine("Received data from client");
                // Signal that all bytes have been received.
                receiveDone.Set();
            }
            Console.WriteLine("completed receive callback");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
