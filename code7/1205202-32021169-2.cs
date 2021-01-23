                    while (!cardaxSR.EndOfStream)
                    {                              // this commented out part is what I would like to work but doesn't seem to work.
                        line = cardaxSR.ReadLine();//.Skip(1).Where(item => !String.IsNullOrWhiteSpace(item));
                        value = line.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);  // <-- Remove empty columns while splitting. It has a side-effect: Any record with just a single blank column will also get discarded by the if that follows.
                        if (value.length < 6)
                          continue;
    
                        CardaxDataObject cardaxCsvTest2 = new CardaxDataObject();
    
                        cardaxCsvTest2.EventID = Convert.ToInt32(value[0]);
                        cardaxCsvTest2.FTItemID = Convert.ToInt32(value[1]);
                        cardaxCsvTest2.PayrollNumber = Convert.ToInt32(value[2]);
                        cardaxCsvTest2.EventDateTime = Convert.ToDateTime(value[3]);
                        cardaxCsvTest2.CardholderFirstName = value[4];
                        cardaxCsvTest2.CardholderLastName = value[5];
    
                        Globals.CardaxQueryResult.Add(cardaxCsvTest2);
                    }
