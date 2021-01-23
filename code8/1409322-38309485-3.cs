    private void UpDown1_ValueChanged(object sender, EventArgs e)
    {
        longCalculations ln = new longCalculations();
        ln.LongMethod1(); 
    }
    public class longCalculations
    {
        public void LongMethod1()
        {
            // Arbitrarily long code goes here
        }
    }
