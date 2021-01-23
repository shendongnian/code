    var soonh = 0;
                                var now = DateTime.Now;
                                var soonm = 0;
                                double minutestoadd = timetoadd;
                                int hourstoadd = 0;
                                if (minutestoadd >= 60)
                                {
                                    do
                                    {
                                        minutestoadd = minutestoadd - 60;
                                        hourstoadd++;
                                    }
                                    while (minutestoadd > 60);
                                }
                                soonh = 6 - (Convert.ToInt32(now.Hour));
                                soonm = 60 - ((Convert.ToInt32(now.Minute)));
                                if (soonm < 0)
                                {
                                    var temp = soonm;
                                    soonm = 0;
                                    soonh = soonh - 1;
                                    soonm = 60 + temp;
                                    Console.WriteLine("Sample");
                                }
                                double totalmin = soonm + now.Minute + minutestoadd;
                                if (totalmin >= 60)
                                {
                                    do
                                    {
                                        if (totalmin >= 60)
                                        {
                                            totalmin = totalmin - 60;
                                            hourstoadd = hourstoadd + 1;
                                        }
                                    }
                                    while (totalmin >= 60);
                                    if (soonh < 0)
                                    {
                                        soonh = 0;
                                    }
                                    int totalhour = soonh + now.Hour + hourstoadd;
                                    int totalday = 0;
                                    bool sample = false;
                                    do
                                    {
                                        if (totalhour >= 8)
                                        {
                                            totalhour = totalhour - 7;
                                            totalday = totalday + 1;
                                            sample = true;
                                        }
                                    }
                                    while (totalhour >= 8);
                                    if (sample == true)
                                    {
                                        totalday = totalday - 1;
                                    }
                                    totalhour = totalhour + 7;
                                    if (totalhour + DateTime.Today.Hour >= 15)
                                    {
                                        totalhour = totalhour - 7;
                                    }
                                    if (DateTime.Today.Date.AddDays(totalday) == DateTime.Today)
                                    {
                                        totalday++;
                                    }
                                    EstimatedCompleteDate = (DateTime.Today.Date.AddDays(totalday).AddHours(totalhour).AddMinutes(totalmin).ToString());
                                }
