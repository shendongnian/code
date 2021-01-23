    public class MyClass : IDisposable
    {
        private Thread sensorProcessingThread = null;
        private Queue<SensorData> sensorQueue = new Queue<SensorData>();
        private readonly object _sensorQueueLocker = new object();
        private EventWaitHandle _whSensorEvent = new AutoResetEvent(false);
        public MyClass () {
            sensorProcessingThread = new Thread(sensorProcessingThread_DoWork);
            sensorProcessingThread.Start();
        }
        public void Dispose()
        {
            // Signal the end by sending 'null'
            EnqueueWatchEvent(null);
            sensorProcessingThread.Join();
            _whSensorEvent.Close();
        }
        // The fast sensor data comes in, locks queue, and then
        // enqueues the data, and releases the EventWaitHandle
        private void EnqueueSensorEvent( SensorData wd )
        {
            lock ( _sensorQueueLocker )
            {
                sensorQueue.Enqueue(wd);
                _whSensorEvent.Set();
            }
        }
        // When asynchronous events come in, I just throw them into queue
        private void OnSensorEvent( object sender, MySensorArgs e )
        {
            EnqueueSensorEvent(new SensorData(sender, e));
        }
        // I have several types of events that can come in,
        // they just get packaged up into the same "SensorData"
        // struct, and I worry about the contents later
        private void FileSystem_Changed( object sender, System.IO.FileSystemEventArgs e )
        {
            EnqueueSensorEvent(new SensorData(sender, e));
        }
        // This is the slower process that waits for new SensorData,
        // and processes it. Note, if it sees 'null' as data,
        // then it knows it should quit the while(true) loop.
        private void sensorProcessingThread_DoWork( object obj )
        {
            while ( true )
            {
                SensorData wd = null;
                lock ( _sensorQueueLocker )
                {
                    if ( sensorQueue.Count > 0 )
                    {
                        wd = sensorQueue.Dequeue();
                        if ( wd == null )
                        {
						    // Quit the loop, thread finishes
                            return;
                        }
                    }
                }
                if ( wd != null )
                {
                    try
                    {
					    // Call specific handlers for the type of SensorData that was received
                        if ( wd.isSensorDataType1 )
                        {
                            SensorDataType1_handler(wd.sender, wd.SensorDataType1Content);
                        }
                        else
                        {
                            FileSystemChanged_handler(wd.sender, wd.FileSystemChangedContent);
                        }
                    }
                    catch ( Exception exc )
                    {
					    // My sensor processing also has a chance of failing to process completely, so I have a retry
						// methodology that gives up after 5 attempts
                        if ( wd.NumFailedUpdateAttempts < 5 )
                        {
                            wd.NumFailedUpdateAttempts++;
                            lock ( _sensorQueueLocker )
                            {
                                sensorQueue.Enqueue(wd);
                            }
                        }
                        else
                        {
                            log.Fatal("Can no longer try processing data", exc);
                        }
                    }
                }
                else
                    _whWatchEvent.WaitOne(); // No more tasks, wait for a signal
            }
        }
