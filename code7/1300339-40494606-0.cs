    GsmCommMain comm=new GsmCommMain(/*Set your option here*/);
    string txtMessage="your long message...";
    string txtDestinationNumbers="your destination number";
    //select unicode option by a checkBox or any other control
    bool unicode = chkUnicode.Checked;
    SmsSubmitPdu[] pdu = SmartMessageFactory.CreateConcatTextMessage(txtMessage, unicode, txtDestinationNumbers);
    CommSetting.comm.SendMessages(pdu);
