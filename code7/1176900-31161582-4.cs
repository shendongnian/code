    public void GetVoltage(Object objName, Object objCcaVar)
    {
      DynamicSystemVariable mysys = new DynamicSystemVariable("VTS::M9_Ch3", "AvgVoltage");
      mysys.ValueChanged += this.OnEvent;
    
    }
    
	private void OnEvent(object sender, EventArgs e)
	{
	  mysys_ValueChanged(sender, e, "");
	}
    
    void mysys_ValueChanged(object sender, EventArgs e,String name)
    {       
        DynamicSystemVariable mysys = (DynamicSystemVariable)sender;
        Output.WriteLine(mysys.GetValue().ToString());
        Output.WriteLine("System Variable Changed");
        if (_unwireEvent)
            mysys.ValueChanged -= OnEvent;  // Unregister what you've registered.
    }
