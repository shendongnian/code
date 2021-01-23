    using System;
    using Microsoft.Win32;
    
    public sealed class App 
    {
        static void Main() 
        {         
            // Set the SystemEvents class to receive event notification when a user 
            // preference changes, the palette changes, or when display settings change.
            SystemEvents.SessionEnding+= SystemEvents_SessionEnding;
 
            Console.WriteLine("This application is waiting for system events.");
            Console.WriteLine("Press <Enter> to terminate this application.");
            Console.ReadLine();
        }
    
        // This method is called when a user preference changes.
        static void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e) 
        {
           e.Category);
        }
    
    }
