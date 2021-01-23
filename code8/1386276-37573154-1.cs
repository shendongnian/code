     public static class Helper
     {
        public static void SendMail(string message)
        {
            if(UseInternalMail)
            {
               //do via local SMTP
            }
            else
            {
              //Call a method in 3rd Party assembly, no more using
              SendUsing3rdPartyDll(message);
            }
        }
        private void SendUsing3rdPartyDll(message)
        {     
            3rdPartyDll.Send(message);
        } 
    }
