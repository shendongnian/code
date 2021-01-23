     public override void Listen()
        {
            while (true)
            {
                try
                {
                    try
                    {
                        // read request and build message
                        byte[] frame = SerialTransport.ReadRequest();
                        IModbusMessage request = ModbusMessageFactory.CreateModbusRequest(frame);
                        if (SerialTransport.CheckFrame && !SerialTransport.ChecksumsMatch(request, frame))
                        {
                            string msg = $"Checksums failed to match {string.Join(", ", request.MessageFrame)} != {string.Join(", ", frame)}.";
                            Debug.WriteLine(msg);
                            throw new IOException(msg);
                        }
                        // only service requests addressed to this particular slave
                        if (request.SlaveAddress != UnitId)
                        {
                            Debug.WriteLine($"NModbus Slave {UnitId} ignoring request intended for NModbus Slave {request.SlaveAddress}");
                            continue;
                        }
                        // perform action
                        IModbusMessage response = ApplyRequest(request);
                        // write response
                        SerialTransport.Write(response);
                    }
                    catch (IOException ioe)
                    {
                        Debug.WriteLine($"IO Exception encountered while listening for requests - {ioe.Message}");
                        SerialTransport.DiscardInBuffer();
                    }
                    catch (TimeoutException te)
                    {
                        Debug.WriteLine($"Timeout Exception encountered while listening for requests - {te.Message}");
                        SerialTransport.DiscardInBuffer();
                    }
                    // TODO better exception handling here, missing FormatException, NotImplemented...
                }
                catch (InvalidOperationException)
                {
                    // when the underlying transport is disposed
                    break;
                }
            }
