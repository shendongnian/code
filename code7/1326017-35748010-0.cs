    public  partial class MainWindow : Window
    {
       public System.Timers.Timer myTimer = new System.Timers.Timer();
		public MainWindow()
		    {
    
        //create the timer
        myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent); // Where is it?
        myTimer.Interval = 5;
        myTimer.Enabled = true;
			}
        //...
        void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            myTimer.Enabled = false; //stop timer whilst updating, so updating won't be called again before it's finished
            //update(); //
            myTimer.Enabled = true;
         //   Timer.Elapsed += 5;
        }
    }
	
    public class Car
    {
        public void changeAccel(double val)
        {
	        var myWin = (MainWindow)Application.Current.MainWindow;
            int time = myWin.myTimer.Elapsed; //<-- you cannot use it this way
		
        }
    }
