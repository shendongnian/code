    void Main()
    {
    	var a = new Acquisition();
    	a.Start(new Device());
        // here is a thread inserting a hundred command into the queue at a small interval for testing
    	Thread t = new Thread(() => {
    		for(int i = 0; i < 100; i++)
    		{
    			a.EnqueueCommand(new Command{Id = i});
    			Thread.Sleep(50);
    		}
    	});
    	t.Start();
    	
        // lets wait some time before we terminate the program to see the queue working the Acquisition working through the queue
    	System.Threading.Thread.Sleep(10000);
        // and we kill the Acquisition now
    	a.Stop();
    }
    
    // Define other methods and classes here
    
    public class Acquisition
        {
            public event EventHandler Starting;
            public event EventHandler Started;
            public event EventHandler Stopping;
            public event EventHandler Stopped;
            // changed to the generic EventArgs for the purpose of testing
            public event EventHandler<EventArgs> Acquired;
    
            private AutoResetEvent stopAcquistion;
    
            private Thread acquisitionThread;
    
            // using a multi-threaded queue is better here in your scenario
            private ConcurrentQueue<Command> commandQueue;
    
            protected virtual void InvokeStarting()
            {
    			Console.WriteLine("InvokeStarting");
                if (this.Starting != null)
                    this.Starting(this, EventArgs.Empty);
            }
    
            protected virtual void InvokeStarted()
            {
    			Console.WriteLine("InvokeStarted");
                if (this.Started != null)
                    this.Started(this, EventArgs.Empty);
            }
    
            protected virtual void InvokeStopping()
            {
    			Console.WriteLine("InvokeStopping");
                if (this.Stopping != null)
                    this.Stopping(this, EventArgs.Empty);
            }
    
            protected virtual void InvokeStopped()
            {
    			Console.WriteLine("InvokeStopped");
                if (this.Stopped != null)
                    this.Stopped(this, EventArgs.Empty);
            }
    
            public bool IsRunning { get; private set; }
    
            public object CurrentDevice { get; private set; }
    
            private void AcquisitionThread(object parameter)
            {
                var device = parameter as Device;
    
                if (parameter == null)
                    throw new ArgumentException("parameter");
    
                var handles = new WaitHandle[] {this.stopAcquistion};
    
                bool stop = false;
    
                this.IsRunning = true;
    
                while (!stop)
                {
                    try
                    {
    					if (!commandQueue.IsEmpty)
    					{
    						Command cmd;
    						if(commandQueue.TryDequeue(out cmd))
    						{
    							TransmitCommand(device, cmd);
    						}
    					}
    
    					if(stopAcquistion.WaitOne(100))
                        {
                           stop = true;
                           continue;
    					}
    
                        if (!this.Acquire(device))
                            break;
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e);
    
                        break;
                    }
                }
    
    			
                device = null;
                stopAcquistion = null;
    
                this.IsRunning = false;
            }
    
            public void EnqueueCommand(Command command)
            {
    			Console.WriteLine(String.Format("EnqueueCommand: {0}", command.Id));
                if(this.commandQueue == null)
                    return;
    
                lock (this.commandQueue)
                    this.commandQueue.Enqueue(command);
    
                //this.sendCommand.Set();
            }
    
            protected virtual void TransmitCommand(object device, Command command)
            {
    			Console.WriteLine(String.Format("TransmitCommand: {0}", command.Id));
            }
    
            protected virtual bool Acquire(Device d)
            {
                return true;
            }
    
            public void Start(Device device)
            {
                this.InvokeStarting();
    
                this.CurrentDevice = device;
    
                this.acquisitionThread = new Thread(AcquisitionThread);
                this.acquisitionThread.Start(device);
    
                this.stopAcquistion = new AutoResetEvent(false);
                // using a multi-threaded queue is better here in your scenario
                this.commandQueue = new ConcurrentQueue<Command>();
    
                this.InvokeStarted();
            }
    
            protected virtual void InvokeAquired(byte[] bytes, int count)
            {
    			Console.WriteLine("InvokeAquired");
                if (this.Acquired != null)
    				this.Acquired(this, new EventArgs());
            }
    
            public void Stop()
            {
                if (this.stopAcquistion == null)
                    return;
    
                this.InvokeStopping();
                this.stopAcquistion.Set();
                this.InvokeStopped();
            }
        }
    // I needed to implement an empty Command, and Device to make the code works in my example
    public class Command{ public int Id {get;set;} }
    public class Device{}
