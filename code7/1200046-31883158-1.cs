    protected void ProcessReceivedMessages()
    {
        byte[] buffer = null;
        int maxSize = AbstractNetworkUtils.GetMaxMessageSize();
        while (!this._isDone)
        {
            Thread.Sleep(1000);
            try
            {
                buffer = new byte[maxSize * 2];
                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                args.RemoteEndPoint = this._remoteEP;
                args.SetBuffer(buffer, 0, buffer.Length);
                args.Completed += new EventHandler<SocketAsyncEventArgs>(delegate (object s, SocketAsyncEventArgs e)
                {
                    if (e.SocketError == SocketError.Success)
                    {
                        byte[] udpMsg = new byte[e.BytesTransferred];
                        // Retrieve the data from the buffer
                        Array.Copy(e.Buffer, udpMsg, e.BytesTransferred);
                        byte mType = AbstractCoAPMessage.PeekMessageType(udpMsg);
                        if ((mType == CoAPMessageType.CON ||
                                mType == CoAPMessageType.NON) && AbstractCoAPMessage.PeekIfMessageCodeIsRequestCode(udpMsg))
                        {
                            //This is a request
                            CoAPRequest coapReq = new CoAPRequest();
                            coapReq.FromByteStream(udpMsg);
                            coapReq.RemoteSender = this._remoteEP;//Setup who sent this message
                            string uriHost = ((IPEndPoint)this._remoteEP).Address.ToString();
                            UInt16 uriPort = (UInt16)((IPEndPoint)this._remoteEP).Port;
                            //setup the default values of host and port
                            //setup the default values of host and port
                            if (!coapReq.Options.HasOption(CoAPHeaderOption.URI_HOST))
                                coapReq.Options.AddOption(CoAPHeaderOption.URI_HOST, AbstractByteUtils.StringToByteUTF8(uriHost));
                            if (!coapReq.Options.HasOption(CoAPHeaderOption.URI_PORT))
                                coapReq.Options.AddOption(CoAPHeaderOption.URI_PORT, AbstractByteUtils.GetBytes(uriPort));
                            this.HandleRequestReceived(coapReq);
                        }
                        else
                        {
                            //This is a response
                            CoAPResponse coapResp = new CoAPResponse();
                            coapResp.FromByteStream(udpMsg);
                            coapResp.RemoteSender = this._remoteEP;//Setup who sent this message
                                                                    //Remove the waiting confirmable message from the timeout queue
                            if (coapResp.MessageType.Value == CoAPMessageType.ACK ||
                            coapResp.MessageType.Value == CoAPMessageType.RST)
                            {
                                this._msgPendingAckQ.RemoveFromWaitQ(coapResp.ID.Value);
                            }
                            this.HandleResponseReceived(coapResp);
                        }
                    }
                });
                this._clientSocket.ReceiveAsync(args);
            }
            catch (SocketException se)
            {
                //Close this client connection
                this._isDone = true;
                this.HandleError(se, null);
            }
            catch (ArgumentNullException argEx)
            {
                this.HandleError(argEx, null);
            }
            catch (ArgumentException argEx)
            {
                this.HandleError(argEx, null);
            }
            catch (CoAPFormatException fEx)
            {
                //Invalid message..
                this.HandleError(fEx, null);
            }
        }
    }
