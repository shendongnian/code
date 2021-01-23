    RawMessage rawMessage;
	using (MemoryStream memoryStream = ConvertMailMessageToMemoryStream(gMessage))
	{
		rawMessage = new RawMessage(memoryStream);
	}
	SendRawEmailRequest request = new SendRawEmailRequest();
	request.RawMessage = rawMessage;
	request.Destinations.Add(MessageToSend.ToRecipient.Trim().ToLower());
	request.Source = MessageToSend.SenderEmail;
	var ses = new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient(UserName, sMailPassword, Amazon.RegionEndpoint.USEast1);
    SendRawEmailResponse response = ses.SendRawEmail(request);
