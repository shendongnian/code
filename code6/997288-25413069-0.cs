    private void step1_DoWork(object sender, DoWorkEventArgs e)
    {
        if (someCondition)
        {
            step1.CancelAsync();                
        }
    
        if (!step1.CancellationPending)
        {
        	// code I do not want to execute
        }
        else
        {
        	e.Cancel = true;
        	return;
        }
    }
