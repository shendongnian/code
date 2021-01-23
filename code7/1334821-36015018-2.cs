        foreach(KeyValuePair<string, List<DataRecords>> kvp in vSummaryResults)
            {
                string sKey = kvp.Key;
                List<DataRecords> list = kvp.Value;
                string[] vArr = sKey.Split(',');
                
                int iTotalTradedQuant = 0;
                double dAvgPrice = 0;
                double dSumQuantPrice = 0;
                double dQuantPrice = 0;
                double dNumClose = 0;
                foreach (DataRecords rec in list)
                {
                    if(vSummaryResults.ContainsKey(sKey))
                    {
                        iTotalTradedQuant += rec.iQuantity;
                        dQuantPrice = rec.iQuantity * rec.dInputTradePrice;
                        dSumQuantPrice += dQuantPrice;
                        dAvgPrice = dSumQuantPrice / iTotalTradedQuant;
                        dNumClose = rec.dNumericClosingPrice;
                           
                    }
                    else
                    {
                        vSummaryResults.Add(sKey, list);
                        //dNumClose = rec.dNumericClosingPrice;
                    }
