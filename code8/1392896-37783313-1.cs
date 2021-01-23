     if(CurrentPosition.Value != 0){
             while (location > -1) {
                switch(location)
                {
    
                    case 0:
                        if(criteria1 && criteria2)
                        {
                            LimitLongsPT.Send(S1 + ((R1 - S1) * BuffZone));
                            LongStopSA.Send(S1 - StopAmount);
                            ShortStopDeep.Send(R1 + StopAmount);
                            TradeManager.ProcessEvents();
                            if(activated == true)
                            {
                                if(PublicFunctions.DoubleEquals(CurrentPosition.Value, 0))
                                {
                                    location = -1;
                                    break;
                                }
                                if(PublicFunctions.DoubleLess(CurrentPosition.Value, 0))
                                {
                                    if(PublicFunctions.DoubleGreater(MP[0], S1) && PublicFunctions.DoubleLess(MP[0], R1))
                                    {
                                        location = 15;
                                        break;
                                    }
                                    if(PublicFunctions.DoubleGreater(MP[0], R1) && PublicFunctions.DoubleLess(MP[0], R2))
                                    {
                                        location = 16;
                                        break;
                                    }
                                    if(PublicFunctions.DoubleGreater(MP[0], S2) && PublicFunctions.DoubleLess(MP[0], S1))
                                    {
                                        location = 23;
                                        break;
                                    }
                                }
                                if(PublicFunctions.DoubleGreater(CurrentPosition.Value, 0))
                                {
                                    if(PublicFunctions.DoubleGreater(MP[0], R1) && PublicFunctions.DoubleLess(MP[0], R2))
                                    {
                                      location = 1;
                                      break;;
                                    }
                                }
                            }
                        }
                        location = 0;
                        break;
                    case 1:
                        if(PublicFunctions.DoubleGreater(CurrentPosition.Value, 0) && PublicFunctions.DoubleGreater(MP[0], R1) && PublicFunctions.DoubleLess(MP[0], R2))
                        {
