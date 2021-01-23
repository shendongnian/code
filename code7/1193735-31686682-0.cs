    foreach (DataRow dRow in mqRequests.Rows)
    {
       try
       {
          outMsg = new MQMessage();
          pmo = new MQPutMessageOptions();
          outMsg.WriteString(dRow[(int)Common.InboundSQLFields.EDB_Message].ToString());
          outMsg.Format = MQC.MQFMT_STRING; // MQFMT_STRING = "MQSTR   ";
    
          /* Put message on Queue */
          pMQQueue.Put(outMsg, pmo);
    
          dRow[(int)Common.InboundSQLFields.MQ_Put_Date] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
          dRow[(int)Common.InboundSQLFields.Message_Status] = "Complete";
          dRow[(int)Common.InboundSQLFields.Last_Modified_Date] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
       }
       catch (MQException mqe)
       {
          switch (mqe.CompletionCode)
          {
             case MQC.MQCC_WARNING:
                //  with warning
                dRow[(int)Common.InboundSQLFields.Message_Status] = "Warning: CC=" + mqe.CompletionCode + ' : RC=' + mqe.ReasonCode;
                dRow[(int)Common.InboundSQLFields.Last_Modified_Date] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
    
                /* Write to log */
                Common.logBuilder("WebSphereMQ --> putMessages <--", "MQWarning", Common.ActiveMQ, dRow[(int)Common.InboundSQLFields.Message_Type].ToString(), "Exception");
                emailer.messageMonitorEmail(dRow[(int)Common.InboundSQLFields.Message_Type].ToString(), Common.ActiveMQ, "Warning: CC=" + mqe.CompletionCode + ' : RC=' + mqe.ReasonCode);
                break;
    
             case MQC.MQCC_FAILED:
    
                dRow[(int)Common.InboundSQLFields.Message_Status] = "Error: CC=" + mqe.CompletionCode + ' : RC=' + mqe.ReasonCode;
                dRow[(int)Common.InboundSQLFields.Last_Modified_Date] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
    
                /* Write to log */
                Common.logBuilder("WebSphereMQ --> putMessages <--", "MQFAIL", Common.ActiveMQ, dRow[(int)Common.InboundSQLFields.Message_Type].ToString(), "Exception");
                emailer.messageMonitorEmail(dRow[(int)Common.InboundSQLFields.Message_Type].ToString(), Common.ActiveMQ, "Warning: CC=" + mqe.CompletionCode + ' : RC=' + mqe.ReasonCode);
                break;
          }
    
          /* Write to log */
          Common.logBuilder("WebSphereMQ --> putMessages <--", "MQException", Common.ActiveMQ, mqe.Message, "CC=" + mqe.CompletionCode + ' : RC=' + mqe.ReasonCode);
          emailer.exceptionEmail(mqe);
    
          // Return nothing
          return;
       }
       catch (Exception ex)
       {
          dRow[(int)Common.InboundSQLFields.Message_Status] = "Error:\t" + ex.Message;
          dRow[(int)Common.InboundSQLFields.Last_Modified_Date] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
          /* Write to log */
          Common.logBuilder("WebSphereMQ --> putMessages <--", "Exception", Common.ActiveMQ, ex.Message, "Exception");
          emailer.exceptionEmail(ex);
          // Return nothing
          return;
       }
    }
