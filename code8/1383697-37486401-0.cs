        private bool VerifyConnection(Socket socket)
        {
            byte[] b = new byte[1];
            try
            {
                if (socket.Receive(b, 0, 1, SocketFlags.None) == 0)
                    throw new SocketException(System.Convert.ToInt32(SocketError.ConnectionReset));
                socket.NoDelay = true;
                socket.Send(new byte[1] { SocketHelper.HelloByte });
                socket.NoDelay = false;
            }
            catch (Exception e)
            {
                this._logger.LogException(LogLevel.Fatal, e, "Attempt to connect (from: [{0}]), but encountered error during reading initialization message", socket.RemoteEndPoint);
                socket.TryCloseSocket(this._logger);
                return false;
            }
            if (b[0] != SocketHelper.HelloByte)
            {
                this._logger.Log(LogLevel.Fatal,
                    "Attempt to connect (from: [{0}]), but incorrect initialization byte sent: [{1}], Ignoring the attempt",
                    socket.RemoteEndPoint, b[0]);
                socket.TryCloseSocket(this._logger);
                return false;
            }
            return true;
        }
