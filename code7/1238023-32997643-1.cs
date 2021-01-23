    using System;
    using System.Management.Automation;
    using System.Threading;
    
    // This code was build from MSDN Blogs entry by Keith Babinec
    // http://blogs.msdn.com/b/kebab/archive/2014/04/28/executing-powershell-scripts-from-c.aspx
    
    namespace ConsoleApplication1
    {
        class PowerShellHelper
        {
            private PowerShell shell_;
    
            public PowerShellHelper(PowerShell shell)
            {
                shell_ = shell;
            }
            public void ExecuteAsynchronously(TimeSpan timeout)
            {
                // prepare a new collection to store output stream objects
                PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();
                outputCollection.DataAdded += outputCollection_DataAdded;
    
                // begin invoke execution on the pipeline
                // use this overload to specify an output stream buffer
                IAsyncResult result = shell_.BeginInvoke<PSObject, PSObject>(null, outputCollection);
    
                // start the timer
                DateTime startTime = DateTime.Now;
    
                // do something else until execution has completed.
                // this could be sleep/wait, or perhaps some other work
                while (result.IsCompleted == false)
                {
                    Console.WriteLine("Waiting for pipeline to finish...");
                    Thread.Sleep(100);
    
                    // we check on our timeout here
                    TimeSpan elasped = DateTime.Now.Subtract(startTime);
                    if (elasped > timeout)
                    {
                        // we can do a few things here, I like to throw exception
                        throw new TimeoutException("Powershell script taking too long");
                    }
                }
    
                Console.WriteLine("Execution has stopped. The pipeline state: " + shell_.InvocationStateInfo.State);
    
                foreach (PSObject outputItem in outputCollection)
                {
                    //TODO: handle/process the output items if required
                    if (outputItem != null)
                    {
                        Console.WriteLine(outputItem.BaseObject.ToString());
                    }
                }
            }
    
            /// <summary>
            /// Event handler for when data is added to the output stream.
            /// </summary>
            /// <param name="sender">Contains the complete PSDataCollection of all output items.</param>
            /// <param name="e">Contains the index ID of the added collection item and the ID of the PowerShell instance this event belongs to.</param>
            private void outputCollection_DataAdded(object sender, DataAddedEventArgs e)
            {
                // do something when an object is written to the output stream
                Console.WriteLine("Object added to output.");
            }
        }
    }
