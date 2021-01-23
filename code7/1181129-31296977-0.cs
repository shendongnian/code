        /// <summary>
        /// Get Message From socket
        /// </summary>
        /// <returns></returns>
        public String getMessageFromSocket()
        {
            try
            {
                byte[] inStream = new byte[10025];
                int bytesRead = socket.GetStream().Read(inStream, 0, inStream.Length);
                return System.Text.Encoding.ASCII.GetString(inStream, 0, bytesRead);
            }
            catch (Exception ex)
            {
                throw new Exception("Message could not be read.\nError: " + ex.Message);
            }
        }
