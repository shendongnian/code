    MQQueue outQ = null;
    MQPutMessageOptions pmo = new MQPutMessageOptions();
    try
    {
       outQ = qmgr.AccessQueue( inMsg.ReplyToQueueName.Trim(),
                                MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING );
    
       outQ.Put(outMsg, pmo);
    }
    catch (MQException mqe)
    {
       System.Console.WriteLine("MQException CC=" + mqe.CompletionCode + " : RC=" + mqe.ReasonCode);
    }
    finally
    {
       try
       {
          if (outQ != null)
             outQ.Close();  // Close the Queue
       }
       catch (MQException mqe)
       {
          System.Console.WriteLine("MQException CC=" + mqe.CompletionCode + " : RC=" + mqe.ReasonCode);
       }
    }
