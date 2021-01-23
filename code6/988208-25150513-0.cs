    void worker_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
               _RunCompleted();
            }
    
    
    private void _RunCompleted(){
    MethodInvoker action = delegate
                {
               bar.Hide();
                bar.Close();
                barExists = false;
    };
    }
