    private static byte[] GeneratePayload(NotificationPayload payload)
        {
          try
          {
            //convert Devide token to HEX value.
            byte[] deviceToken = new byte[payload.DeviceToken.Length / 2];
            for (int i = 0; i < deviceToken.Length; i++)
                deviceToken[i] = byte.Parse(payload.DeviceToken.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
    
            var memoryStream = new MemoryStream();
    
            BinaryWriter writer = new BinaryWriter(memoryStream);
    
            writer.Write((byte)0);  //The command
            writer.Write((byte)0);  //The first byte of the deviceId length (big-endian first byte)
            writer.Write((byte)32); //The deviceId length (big-endian second byte)
    
            writer.Write(deviceToken);       
    
            writer.Write((byte)0); //First byte of payload length; (big-endian first byte)        
            byte[] b1 = System.Text.Encoding.UTF8.GetBytes(payload.ToJson());
            writer.Write((byte)b1.Length);       
            writer.Write(b1);
            writer.Flush();
    
            byte[] array = memoryStream.ToArray();
    
            // Command
            memoryStream.WriteByte(1); // Changed command Type 
    
            //Adding ID to Payload                  
            memoryStream.Write(Encoding.ASCII.GetBytes(payload.PayloadId.ToString()), 0, payload.PayloadId.ToString().Length);
    
            //Adding ExpiryDate to Payload
            int epoch = (int) (DateTime.UtcNow.AddMinutes(300) - new DateTime(1970, 1, 1)).TotalSeconds;
            byte[] timeStamp = BitConverter.GetBytes(epoch);
            memoryStream.Write(timeStamp, 0, timeStamp.Length);
    
            byte[] tokenLength = BitConverter.GetBytes((Int16) 32); 
            Array.Reverse(tokenLength);
            // device token length
            memoryStream.Write(tokenLength, 0, 2);
    
            // Token
            memoryStream.Write(deviceToken, 0, 32);
    
          // String length
            string apnMessage = payload.ToJson(); 
            Logger.Info("Payload generated for " + payload.DeviceToken + " : " + apnMessage);
    
            byte[] apnMessageLength = BitConverter.GetBytes((Int16)apnMessage.Length);
            Array.Reverse(apnMessageLength);
    
            // message length
            memoryStream.Write(apnMessageLength, 0, 2); 
    
            // Write the message        
            memoryStream.Write(Encoding.ASCII.GetBytes(apnMessage), 0, apnMessage.Length);
            return array;
          }
          catch (Exception ex)
          {
            Logger.Error("Unable to generate payload - " + ex.Message);
            return null;
          }
        }
