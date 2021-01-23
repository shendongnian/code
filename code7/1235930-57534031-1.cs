    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Diagnostics.Tracing; // you need to add the Microsoft.Diagnostics.Tracing.TraceEvent nuget package
    using Microsoft.Diagnostics.Tracing.Session;
    namespace TraceTest
    {
        class Program
        {
            static void Main()
            {
                // create a real time user mode session
                using (var session = new TraceEventSession("MySession"))
                {
                    // use UWP logging channel provider
                    session.EnableProvider(new Guid("01234567-01234-01234-01234-012345678901")); // use the same guid as for your LoggingChannel
                    session.Source.AllEvents += Source_AllEvents;
                    // Set up Ctrl-C to stop the session
                    Console.CancelKeyPress += (object s, ConsoleCancelEventArgs a) => session.Stop();
                    session.Source.Process();   // Listen (forever) for events
                }
            }
            private static void Source_AllEvents(TraceEvent obj)
            {
                // note: this is for the LoggingChannel.LogMessage Method only! you may crash with other providers or methods
                var len = (int)(ushort)Marshal.ReadInt16(obj.DataStart);
                var stringMessage = Marshal.PtrToStringUni(obj.DataStart + 2, len / 2);
                // Output the event text message. You could filter using level.
                // TraceEvent also contains a lot of useful informations (timing, process, etc.)
                Console.WriteLine(obj.Level + ":" + stringMessage);
            }
        }
    }
