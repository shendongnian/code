    private void comm_MessageReceived(object sender, MessageReceivedEventArgs e)
    {
    	var obj = e.IndicationObject;
    	if (obj is MemoryLocation)
    	{
    		var loc = (MemoryLocation)obj;
    		var msg = string.Format("New message received in storage \"{0}\", index {1}.",
    								loc.Storage, loc.Index);
    		MessageBox.Show(msg);
    		
    		DecodedShortMessage[] messages = CommSetting.comm.ReadMessages(PhoneMessageStatus.All, PhoneStorageType.Sim);
    		foreach (DecodedShortMessage message in messages)
    		{
    			DisplayMessage(message.Data);
    		}
    		return;
    	}
    }
    
    private void DisplayMessage(SmsPdu pdu)
    {
    	if (pdu is SmsDeliverPdu)
    	{
    		SmsDeliverPdu data = (SmsDeliverPdu)pdu;
    		var phoneNumber = data.OriginatingAddress; 
    		var msg = data.UserDataText;
    		var date = string.Format("{0:dd/MM/yyyy}", data.SCTimestamp.ToDateTime());
    		var time = string.Format("{0:HH:mm:ss}", data.SCTimestamp.ToDateTime());
    		
    		//read message in listBox1
    		listBox1.Items.Add(string.Format("{0}, {1}, {2}, {3}", date, time, phoneNumber, msg));
    	}
    }
