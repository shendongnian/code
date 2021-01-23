    public event EventHandler MyPropertyChanged
    {
    	add { textBox1.TextChanged += value; }
    	remove { textBox1.TextChanged -= value; }
    }
