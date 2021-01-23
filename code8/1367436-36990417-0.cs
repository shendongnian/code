    EventHandler valueChanged;
    public event EventHandler ValueChanged
    {
    	add { valueChanged += value; }
    	remove { valueChanged -= value; }
    }
    
    private void OnValueChanged(EventArgs e)
    {
    	EventHandler handler = valueChanged;
    	if (handler != null)
    		handler(this, e);
    }
