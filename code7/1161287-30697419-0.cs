    using System.Timers;    
    public class Program{
        
                private static Timer aTimer;
    
            public static void Main(string[] args){
                // Create a timer with a one second interval.
                aTimer = new System.Timers.Timer(1000);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += OnTimedEvent;
                aTimer.Enabled = true;
    
                Console.WriteLine("Press the Enter key to exit the program... ");
                Console.ReadLine();
                Console.WriteLine("Terminating the application...");
            }
            private static void OnTimedEvent(Object source, ElapsedEventArgs e) {
                //Call Save NotePad File
                Console.WriteLine("The Notepad files was saved. Elapsed event was raised at {0}", e.SignalTime);
            }
    
    
        }
