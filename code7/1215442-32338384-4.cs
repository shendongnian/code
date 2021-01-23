     List<SingleCardDetails> cardDetails = new List<SingleCardDetails>();
            foreach (var item in expando)
                {
                    if (item.Value is ExpandoObject)
                    {
                        var store = item.Value as IDictionary<string, object>;
                        // check properties are on first level
                        if (!store.Keys.Contains("bizcardData")) 
                        {
                            cardDetails.Add(TryGetData(store));
                        }
                        else // check second level where contact details are under bizcardData
                        {
                            foreach (var level2 in item.Value as IDictionary<string, object>)
                            {
                                if (level2.Value is ExpandoObject)
                                {
                                    var storeLevel2 = level2.Value as IDictionary<string, object>;
    
                                    cardDetails.Add(TryGetData(storeLevel2));
                                }
                            }
                        }
                    }
                }
