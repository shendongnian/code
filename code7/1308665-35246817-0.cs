        public class SerialQueue
        {
            SerialPort sp;
            ManualResetEvent processQueue = new ManualResetEvent(false);
            Queue<QueueCommand> queue = new Queue<QueueCommand>();
            public event EventHandler<ReadEventArgs> ReadSuccess;
            public event EventHandler<IdEventArgs> WriteSuccess;
            public SerialQueue()
            {
                ThreadPool.QueueUserWorkItem(ProcessQueueThread);
                sp = new SerialPort(); //Initialize it according to your needs.
                sp.Open();
            
            }
            void ProcessQueueThread(object state)
            {
                while (true)
                {
                    processQueue.WaitOne();
                    QueueCommand cmd;
                    while(true)
                    {
                        lock (queue)
                        {
                            if (queue.Count > 0)
                                cmd = queue.Dequeue();
                            else
                            {
                                processQueue.Reset();
                                break;
                            }
                        }
                        if (cmd.Operation == SerialOperation.Write || cmd.Operation == SerialOperation.WriteRead)
                        {
                            sp.Write(cmd.BytesToWrite, 0, cmd.BytesToWrite.Length);
                            if (WriteSuccess != null)
                                WriteSuccess(this, new IdEventArgs { Id = cmd.Id });
                        }
                        if(cmd.Operation == SerialOperation.Read || cmd.Operation == SerialOperation.WriteRead)
                        {
                            byte[] buffer = new byte[cmd.BytesToRead];
                            sp.Read(buffer, 0, buffer.Length);
                            if (ReadSuccess != null)
                                ReadSuccess(this, new ReadEventArgs { Id = cmd.Id, Data = buffer });
                        }
                    }
                }
            
            }
        
            public void EnqueueCommand(QueueCommand Command)
            {
                lock(queue)
                {
                    queue.Enqueue(Command);
                    processQueue.Set();
                }
            }
        }
