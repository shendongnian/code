            while (true)
            {
                Socket handler = listener.Accept();
                data = null;
                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    TextRecieved = data;
                    Thread textbox = new Thread(new ThreadStart(WriteInReachTextBox));
                    textbox.Start();
    // -----------> HERE!!!!!!
                    break;
                }
                //uirtbreport.Text = data;
                byte[] msg = Encoding.ASCII.GetBytes(data);
                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
