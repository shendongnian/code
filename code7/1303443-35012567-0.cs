            /// <summary>
            /// Method designed to allow the sending of Byte[] data to the Peer
            /// Because this is using NetworkStreams - the first 4 bytes sent is the data length
            /// </summary>
            /// <param name="TheMessage"></param>
            public void SendBytesToPeer(byte[] TheMessage)
            {
    
                try
                {
                    long len = TheMessage.Length;
    
                    byte[] Bytelen = BitConverter.GetBytes(len);
    
                    PeerStream.Write(Bytelen, 0, Bytelen.Length);
                    PeerStream.Flush();
                    PeerStream.Write(TheMessage, 0, TheMessage.Length);
                    PeerStream.Flush();
                }
                catch (Exception e)
                {
                    //System.Windows.Forms.MessageBox.Show(e.ToString());
                }
            }
