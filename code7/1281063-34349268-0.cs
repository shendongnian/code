            public String PingTest(string asMac)
            {
                String lsReturn = "";
                try
                {
                    Ping pingreq = new Ping();
                    PingReply rep = pingreq.Send(asMac);
                    if (rep.Status == IPStatus.Success)
                    {
                        lsReturn = "Success"
                        return lsReturn;
                    }
                    else
                    {
                        lsReturn = "Error Pinging " + asMac + " " + rep.Status;
                    }
    
                }
                catch (PingException pEx)
                {
                    lsReturn = "PingException Error Pinging " + asMac + " " + pEx.Message + Environment.NewLine + pEx.StackTrace;
                }
                catch (NetworkInformationException nEx)
                {
                    lsReturn = "NetworkInformationException Error Pinging " + asMac + " " + nEx.Message + Environment.NewLine + nEx.StackTrace;
                }
                catch (Exception ex)
                {
                    lsReturn = "Error Pinging " + asMac + " " + ex.Message + Environment.NewLine + ex.StackTrace;
                }
                return lsReturn;
           }
