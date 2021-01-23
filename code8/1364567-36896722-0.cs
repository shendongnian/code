    using System.Timers;
    
    namespace Example {
        static Timer _timer;
    
        static void Main() {
            _timer = new Timer(1000); // Update every 1 second.
            _timer.Elapsed += UpdateMyLabel;
            _timer.Start();
        }
    
        static void UpdateMyLabel(object sender, ElapsedEventArgs e) {
            label1.Text = DateTime.Now.Hour;
        }
    }
