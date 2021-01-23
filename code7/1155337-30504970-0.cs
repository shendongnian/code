		private const string LT = "\r\n";
		public void Auth(string pin)
		{
			lock (smsSendSync)
			{
				//Check if gateway is alive
				lastSplit = SplitResponse(SendCommand("AT"));
				if (!(lastSplit[lastSplit.Length - 1] == "OK"))
					throw new OperationCanceledException("AT connection failed");
				//Echo ON
				lastSplit = SplitResponse(SendCommand("ATE1"));
				if (!(lastSplit[lastSplit.Length - 1] == "OK"))
					throw new OperationCanceledException("ATE command failed");
				//Check echo
				lastSplit = SplitResponse(SendCommand("AT"));
				if (!(lastSplit.Length == 2 && lastSplit[1] == "OK"))
					throw new OperationCanceledException("AT command failed");
				//Verbose error reporting
				lastSplit = SplitResponse(SendCommand("AT+CMEE=2"));
				if (!(lastSplit.Length == 2 && lastSplit[1] == "OK"))
					throw new OperationCanceledException("AT+CMEE command failed");
				//Enter a PIN
				lastSplit = SplitResponse(SendCommand("AT+CPIN?"));
				if (!(lastSplit.Length == 3 && lastSplit[2] == "OK"))
					throw new OperationCanceledException("AT+CPIN? command failed");
				switch (lastSplit[1])
				{
					case "+CPIN: READY": //no need to enter PIN
						break;
					case "+CPIN: SIM PIN": //PIN requested
						lastSplit = SplitResponse(SendCommand("AT+CPIN=" + pin));
						string m_receiveData = String.Empty;
						WaitForResponse(out m_receiveData);
						if (m_receiveData == String.Empty)
							throw new OperationCanceledException("PIN authentification timed out");
						break;
					default:
						throw new OperationCanceledException("Unknown PIN request");
				}
				//Check if registered to a GSM network
				lastSplit = SplitResponse(SendCommand("AT+CREG?"));
				if (!(lastSplit.Length == 3 && lastSplit[2] == "OK"))
					throw new OperationCanceledException("AT+CREG? command failed");
				lastSplit = lastSplit[1].Split(new string[] {" ", ","}, StringSplitOptions.RemoveEmptyEntries);
				if (!(lastSplit[2] == "1" || lastSplit[2] == "5"))
					throw new OperationCanceledException("Not registered to a GSM network");
				Debug.WriteLine("Authentification successfull");
			}
		}
		private string[] SplitResponse(string response)
		{
			string[] split = response.Split(new string[] { LT }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < split.Length; i++)
				split[i] = split[i].Trim();
			return split;
		}
		public string SendCommand(string command)
		{
			string m_receiveData = string.Empty;
			smsPort.ReadExisting();		//throw away any garbage
			smsPort.WriteLine(command + LT);
			WaitForResponse(out m_receiveData);
			//Debug.WriteLine(m_receiveData);
			return m_receiveData;
		}
		public string SendSms2(string phoneNumber, string message, bool flashMsg, SMS.SMSEncoding encoding)
		{
			if (phoneNumber.StartsWith("00"))
				phoneNumber = "+" + phoneNumber.Substring(2);
			if (phoneNumber.StartsWith("0"))
                //replace with your national code
				phoneNumber = "+386" + phoneNumber.Substring(1); 
			string StatusMessage = string.Empty;
			SMS sms = new SMS();							//Compose PDU SMS
			sms.Direction = SMSDirection.Submited;			//Setting direction of sms
			sms.Flash = flashMsg;							//Sets the flash property of SMS
			sms.PhoneNumber = phoneNumber.Replace(" ","");	//Set the recipient number
			sms.MessageEncoding = encoding;					//Sets the Message encoding for this SMS
			sms.ValidityPeriod = new TimeSpan(4, 0, 0, 0);	//Set validity period
			sms.Message = message;							//Set the SMS Message text
			string sequence = sms.Compose() + CtrlZ;		//Compile PDU unit
			string sequenceLength = ((sequence.Length - 3) / 2).ToString();
			lock (smsSendSync)
			{
				StatusMessage = SendCommand("AT+CMGS=" + sequenceLength) + " ";
				Thread.Sleep(500);
				StatusMessage += SendCommand(sequence);
			}
			Debug.WriteLine(StatusMessage);
			if (StatusMessage.Contains("ERROR"))
				throw new OperationCanceledException("Error sending SMS");
			return StatusMessage;
		}
