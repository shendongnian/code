    // Read the first batch of the TcpServer response bytes.
                var bytes = new byte[512];
                // Loop to receive all the data sent by the Server.
                var sb = new StringBuilder();
                do
                {
                    var i = stream.Read(bytes, 0, bytes.Length);
                    sb.AppendFormat("{0}", Encoding.ASCII.GetString(bytes, 0, i));
                } while (stream.DataAvailable);
