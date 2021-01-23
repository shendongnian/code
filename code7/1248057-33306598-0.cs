void ProcessCode() 
    {
    	while(true) {
            //assuming that the Listen method blocks and waits for a message to be received.
    		var message = theListener.Listen("manager, "theQueue");
    		HandleMessage(message);
    	}
    }
also note that you probably want to put in some logic to be able to stop processing messages for when you need to shut the service down.
