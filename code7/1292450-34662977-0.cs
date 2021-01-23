    private int _temp1;
    public int temp1{
	get { return _temp1; }
	set { 
        _temp1= value; 
        this.tempTextBox.Text = value;
        }
    }
