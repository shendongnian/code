    private void RepeatFunction()
    {
    	if (!this.RepeatChecked)
    	{
    		Console.WriteLine("Not checked");
    		////this.RepeatChecked = true;
    		this.stateRepeat = StateRepeat.ONE;
    	}
    	else if (this.RepeatChecked && this.stateRepeat == StateRepeat.ONE)
    	{
    		Console.WriteLine("Not checked - 2");
    		////this.RepeatChecked = true;
    		this.stateRepeat = StateRepeat.ALL;
    	}
    	else if (this.RepeatChecked)
    	{
    		Console.WriteLine("Checked");
    		////this.RepeatChecked = false;
    		this.stateRepeat = StateRepeat.NONE;
    	}
    }
