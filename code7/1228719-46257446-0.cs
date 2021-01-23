    private static int IsForwardOrReplyMail(ExchangeService service, EmailMessage messageToCheck)
        {
            try
            {
                // Create extended property definitions for PidTagLastVerbExecuted and PidTagLastVerbExecutionTime.
                ExtendedPropertyDefinition PidTagLastVerbExecuted = new ExtendedPropertyDefinition(0x1081, MapiPropertyType.Integer);
                ExtendedPropertyDefinition PidTagLastVerbExecutionTime = new ExtendedPropertyDefinition(0x1082, MapiPropertyType.SystemTime);
                PropertySet propSet = new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.Subject, PidTagLastVerbExecutionTime, PidTagLastVerbExecuted);
                messageToCheck = EmailMessage.Bind(service, messageToCheck.Id, propSet);
                // Determine the last verb executed on the message and display output.
                object responseType;
                messageToCheck.TryGetProperty(PidTagLastVerbExecuted, out responseType);
                if (responseType != null && ((Int32)responseType) == 104)
                {
                    //FORWARD
                    return 104;
                }
                else if (responseType != null && ((Int32)responseType) == 102)
                {
                    //REPLY
                    return 102;
                }
            }
            catch (Exception)
            {
                return 0;
                //throw new NotImplementedException();
            }
        }
