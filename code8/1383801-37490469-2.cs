    public class TEST_Worker 
    {
        public event EventHandler OnCompleted = delegate { };
    
        // ....
    
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnCompleted(this, EventArgs.Empty);
        }
    }
    
    // In form:
    
    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
        TEST.TEST_Worker myTest = new TEST.TEST_Worker();
    
        myTest.OnCompleted += (_sender, _e) => {
            MessageBox.Show("Complete!");
        };
        
        myTest.start();
    }
