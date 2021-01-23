    private decimal grandTotal = 0;
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
            decimal costperSec = 0.095703125m;
            decimal total = costperSec + costperSec;
            grandTotal = decimal.Add(total, costperSec);
            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
            lblSeconds.Content = grandTotal;
            //For testing
            //lblSeconds.Content = "-" + "$" + DateTime.Now.Second;
    }
