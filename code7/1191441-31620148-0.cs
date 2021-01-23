    MQMessage outMsg = new MQMessage();
    outMsg.Encoding = MQC.MQENC_NATIVE;
    outMsg.CharacterSet = MQC.MQCCSI_DEFAULT;
    outMsg.Format = MQC.MQFMT_STRING;
    outMsg.MessageId = MQC.MQMI_NONE;
    outMsg.CorrelationId = inMsg.MessageId;
