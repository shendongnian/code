                    while (!cardaxSR.EndOfStream)
                    {                              // this commented out part is what I would like to work but doesn't seem to work.
                        line = cardaxSR.ReadLine();//.Skip(1).Where(item => !String.IsNullOrWhiteSpace(item));
                        if (string.IsNullOrWhiteSpace(line))
                        {
                          continue; // Move to the next iteration (effectively to next line)
                        }
                        value = line.Split(',');
    
                        CardaxDataObject cardaxCsvTest2 = new CardaxDataObject();
    
                        cardaxCsvTest2.EventID = Convert.ToInt32(value[0]);
                        cardaxCsvTest2.FTItemID = Convert.ToInt32(value[1]);
                        cardaxCsvTest2.PayrollNumber = Convert.ToInt32(value[2]);
                        cardaxCsvTest2.EventDateTime = Convert.ToDateTime(value[3]);
                        cardaxCsvTest2.CardholderFirstName = value[4];
                        cardaxCsvTest2.CardholderLastName = value[5];
    
                        Globals.CardaxQueryResult.Add(cardaxCsvTest2);
                    }
