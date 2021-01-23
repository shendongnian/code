                   try
                   {
                        RiotSharp.SummonerEndpoint.Summoner summoner = await api.GetSummonerAsync(region,name);
                        SendSummonersDetails(summoner, e.Message.MessageTarget);
                    }
                    catch (AggregateException ex)
                    {
                      foreach(Exception ee in ex.InnerExceptions
                      {
                        RiotException e = ee as RiotException;
                        string error = string.Format(this.RegionNotFound, command[2]);
                        irc.Send(new IRCMessage("PRIVMSG", e.Message.MessageTarget, error));
                      } 
    
                     }
