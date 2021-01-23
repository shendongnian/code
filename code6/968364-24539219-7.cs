    static class SocketUtils
    {
        public static bool IsConnected(this Socket socket)
        {
            return IsSocketConnected(socket) && IsNetworkConnected(socket);
        }
        public static void KeepAlive(this Socket socket, int pollSeconds)
        {
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            SetIOControlKeepAlive(socket, (uint)(pollSeconds * 1000), 1);
        }
        static bool IsNetworkConnected(this Socket socket)
        {
            try
            {
                return socket.Send(new byte[0]) == 0;
            }
            catch (SocketException) { return false; }
        }
        static bool IsSocketConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }
        static void SetIOControlKeepAlive(Socket socket, uint time, uint interval)
        {
            var sizeOfUint = Marshal.SizeOf(time);
            var inOptionValues = new byte[sizeOfUint * 3];
            BitConverter.GetBytes((uint)(time == 0 ? 0UL : 1UL)).CopyTo(inOptionValues, 0);
            BitConverter.GetBytes(time).CopyTo(inOptionValues, sizeOfUint);
            BitConverter.GetBytes(interval).CopyTo(inOptionValues, sizeOfUint * 2);
            socket.IOControl(IOControlCode.KeepAliveValues, inOptionValues, null);
        }
    }
