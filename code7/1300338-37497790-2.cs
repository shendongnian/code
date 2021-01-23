    using GsmComm.GsmCommunication;
    using GsmComm.PduConverter;
    using GsmComm.PduConverter.SmartMessaging; 
    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    GsmCommMain comm = new GsmCommMain("COM7", 19200, 500);
                    comm.Open();
                    string txtMessage = "Input here very long message please ";
                    string txtDestinationNumbers = "+79235280406";
                    bool unicode = true;  
                    SmsSubmitPdu[] pdu = SmartMessageFactory.CreateConcatTextMessage(txtMessage, unicode, txtDestinationNumbers);
                    comm.SendMessages(pdu);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
