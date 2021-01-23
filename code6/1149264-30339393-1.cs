        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            this.CurrentSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(this.CompleteMessageSending), this.CurrentSocket);
        }
        private void CompleteMessageSending(IAsyncResult asyncResult)
        {
            var client = asyncResult.AsyncState as Socket;
            client.EndSend(asyncResult);
        }
        private void HandleCommandExecutionCompleted(object sender, CommandCompletionArgs e)
        {
            this.SendMessage($"{e.Command} executed.\r\n");
        }
