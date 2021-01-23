     /// <summary>
        /// This is the click handler for the 'CloseSockets' button.
        /// </summary>
        /// <param name="sender">Object for which the event was generated.</param>
        /// <param name="e">Event's parameters.</param>
        private void CloseSockets_Click(object sender, RoutedEventArgs e)
        {
            object outValue;
            if (CoreApplication.Properties.TryGetValue("clientDataWriter", out outValue))
            {
                // Remove the data writer from the list of application properties as we are about to close it.
                CoreApplication.Properties.Remove("clientDataWriter");
                DataWriter dataWriter = (DataWriter)outValue;
                // To reuse the socket with another data writer, the application must detach the stream from the
                // current writer before disposing it. This is added for completeness, as this sample closes the socket
                // in the very next block.
                dataWriter.DetachStream();
                dataWriter.Dispose();
            }
            if (CoreApplication.Properties.TryGetValue("clientSocket", out outValue))
            {
                // Remove the socket from the list of application properties as we are about to close it.
                CoreApplication.Properties.Remove("clientSocket");
                StreamSocket socket = (StreamSocket)outValue;
                // StreamSocket.Close() is exposed through the Dispose() method in C#.
                // The call below explicitly closes the socket.
                socket.Dispose();
            }
            if (CoreApplication.Properties.TryGetValue("listener", out outValue))
            {
                // Remove the listener from the list of application properties as we are about to close it.
                CoreApplication.Properties.Remove("listener");
                StreamSocketListener listener = (StreamSocketListener)outValue;
                // StreamSocketListener.Close() is exposed through the Dispose() method in C#.
                // The call below explicitly closes the socket.
                listener.Dispose();
            }
            CoreApplication.Properties.Remove("connected");
            CoreApplication.Properties.Remove("adapter");
            CoreApplication.Properties.Remove("serverAddress");
            rootPage.NotifyUser("Socket and listener closed", NotifyType.StatusMessage);
        }
