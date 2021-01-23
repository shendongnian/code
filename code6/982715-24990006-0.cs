      TMemoryBuffer trans = new TMemoryBuffer();     //Transport
      TProtocol proto = new TCompactProtocol(trans); //Protocol
      PNWF.Trade trade = new PNWF.Trade(initStuff);  //Message type (thrift struct)
      trade.Write(proto);                    //Serialize the message to memory
      byte[] bytes = trans.GetBuffer();      //Get the serialized message bytes
      //SendAMQPMsg(bytes);                  //Send them!
