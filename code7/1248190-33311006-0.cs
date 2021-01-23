    private void port_DataReceived(object sender, RJCP.IO.Ports.SerialDataReceivedEventArgs e)
    {
	    try
    	{		
	    	SerialPortStream sp = (SerialPortStream)sender;
		    if (sp.BytesToRead > 0)
    		{
	    		int bytes_rx = sp.Read(buffer, 0, BYTES_MAX);			
		    	if (datacollector != null)
			    	datacollector.InsertData(buffer, bytes_rx);
		    }
    	}
    	catch (Exception ex)
    	{
	    	///project specific code here...
    	}
    }
