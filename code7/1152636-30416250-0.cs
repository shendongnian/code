    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace QueueProcessor
    {
    
        class Program
        {
            static Queue<string> _Messages = new Queue<string>();
            static bool _Continue = true;
            static Thread _DequeueThread = null;
            static AutoResetEvent _Latch = null;
            
            static void Main( string[] args )
            {
                _DequeueThread = new Thread( DequeueThread );
                _Latch = new AutoResetEvent(false);
                _DequeueThread.Start();
                for(;;)
                {
                    Console.WriteLine( "Entersomething here:");
                    string something = Console.ReadLine();
                    if( something.Equals("quit") )
                    {
                        _Continue = false;
                        ResumeThread();
                        break;
                    }
                    lock( _Messages )
                    {
                        _Messages.Enqueue( something );
                    }
                    ResumeThread();
                }
            }
    
            static void ResumeThread( )
            {
                _Latch.Set();
            }
    
            static void SuspendThread()
            {
                _Latch.WaitOne();
            }
    
            static void DequeueThread()
            {
                Random randomTime = new Random();
                while( _Continue )
                {
                    SuspendThread();
                    string message = string.Empty;
                    for(;;)
                    {
                        lock ( _Messages )
                        {
                            message = _Messages.Count == 0 ? string.Empty : _Messages.Dequeue();
                        }
    
                        if( String.IsNullOrEmpty( message ) ) break; // Loop exit condition
    
                        Console.WriteLine( String.Format ( "Dequeue:{0}", message ) );
                        int timeout = randomTime.Next();
                        timeout %= 4000;
                        Thread.Sleep(timeout); // simulated taking a while to process message
                    }
                }
            }
        }
    }
