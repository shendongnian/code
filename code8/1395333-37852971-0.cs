    private Action B;
		
	private void Form1_Load()
	{
		B();
	}
	
	
	private void C()  
	{
		if (RadioButton.Checked == false) { B = D; }
		else { B = E; }        
	}
