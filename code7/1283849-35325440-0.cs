            string hostName = "localhost 
            rfidReader = new RFIDReader(hostName, 0, 0);
            try
            {
                rfidReader.Connect();
                AccessComplete = new AutoResetEvent(false);
                rfidReader.Events.NotifyInventoryStartEvent = true;
                rfidReader.Events.NotifyAccessStartEvent = true;
                rfidReader.Events.NotifyAccessStopEvent = true;
                rfidReader.Events.NotifyInventoryStopEvent = true;
                rfidReader.Events.NotifyAntennaEvent = true;
                rfidReader.Events.NotifyBufferFullWarningEvent = true;
                rfidReader.Events.NotifyBufferFullEvent = true;
                rfidReader.Events.NotifyGPIEvent = true;
                rfidReader.Events.NotifyReaderDisconnectEvent = true;
                rfidReader.Events.NotifyReaderExceptionEvent = true;
                rfidReader.Events.AttachTagDataWithReadEvent = false; //true if ReadNotify is ON
                // Regitering for status event notification
                rfidReader.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify);
            // Exclude the events each other for best results in my case I use Status Notify only
                //// Registering for read tag event notification
                //rfidReader.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify);
            }
            catch (OperationFailureException operationFailureException)
            {
               // Handle this exception type
            }
            catch (Exception ex)
            {
                // Handle general exception type
            }
