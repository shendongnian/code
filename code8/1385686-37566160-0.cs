    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace ReliableStop
    {
        class Program
        {
            static void Main(string[] args)
            {
                Debug.WriteLine("-- Started Main. Thread: {0}", Thread.CurrentThread.ManagedThreadId);
    
                var everStarted = new ManualResetEvent(false);
    
                var t = new Thread(o =>
                {
                    Debug.WriteLine("-- Thread entered here.");
                    everStarted.Set();
    
                    using (new PostMortemThreadDump())
                    {
                        try
                        {
                            Thread.Sleep(100);
                        }
                        catch
                        {
                            Debug.WriteLine("-- Attempt to catch everything.");
                        }
                        finally
                        {
                            Debug.WriteLine("-- Attempt to process finally.");
                        }                    
                    }
                });
                t.IsBackground = true;
                t.Start();
    
                // Check that the thread has started.
                everStarted.WaitOne();
    
                // ... Good bye, no need to kill, I will die on my own.
            }
        }
    
        class PostMortemThreadDump : IDisposable
        {
            int threadId { get; }
            public PostMortemThreadDump()
            {
                threadId = Thread.CurrentThread.ManagedThreadId;
            }
    
            ~PostMortemThreadDump()
            {
                Dispose(false);
            }
    
            void Dispose(bool disposing)
            {
                if (disposing)
                {
                    Debug.WriteLine("-- PostMortemThreadDump. Finished normally.");
                }
                else
                {
                    Debug.WriteLine("-- PostMortemThreadDump. Thread: {0}", threadId);
                }
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
