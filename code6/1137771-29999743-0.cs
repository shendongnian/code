                        ITextMessage msg = consumer.Receive () as ITextMessage;
    					ActiveMQTextMessage tmsg = msg as ActiveMQTextMessage;
    					Stream stream = new MemoryStream(tmsg.Content);
    
    					if(tmsg.Compressed == true)
    					{
    						stream = tmsg.Connection.CompressionPolicy.CreateDecompressionStream(stream);                            
    					}
    
                        // TODO read MemoryStream to whatever
