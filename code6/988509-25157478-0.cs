    bool stop = false;
    foreach (string item in Processes)
    {
        if (stop)
            break;
        //do-your-stuff
        Application.DoEvents(); //this will force the winform app to handle events from the GUI
    }
    //Add an eventhandler to your stop-button
    private void stopButton_Click(System.Object sender, System.EventArgs e)
	{
		stop = true;
	}
