    public void GetVoltage(Object objName, Object objCcaVar)
    {
      DynamicSystemVariable mysys = new DynamicSystemVariable("VTS::M9_Ch3", "AvgVoltage");
	  
	  EventHandler handler = null;
	  handler = (s, e) => mysys_ValueChanged(s, e, "", handler);
	  
      mysys.ValueChanged += handler;   
    }
   
    void mysys_ValueChanged(object sender, EventArgs e, String name, EventHandler handler)
    {       
        DynamicSystemVariable mysys = (DynamicSystemVariable)sender;
        Output.WriteLine(mysys.GetValue().ToString());
        Output.WriteLine("System Variable Changed");
        if (_unwireEvent)
            mysys.ValueChanged -= handler;  // Unregister what you've registered.
    }
