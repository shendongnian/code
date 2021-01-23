    private void buttonStart_Click(object sender, EventArgs e)
    {
    	if(!backgroundWorker1.IsBusy)
    	{
    		currentState = StateMachine.SendCmd1;
    		
    		backgroundWorker1.RunWorkerAsync();
    	}
    }
