        int iSumOpen = 0;
            foreach (KeyValuePair<string, List<DataRecord>> kvp in vSummaryResults)
            {
                string key = kvp.Key; //assigns key
                List<DataRecord> list = kvp.Value;  //assigns value
                Console.WriteLine("Key = {0}", key);
                iSumOpen = 0;
                foreach (DataRecord rec in list)
                {
                    if (vSummaryResults.ContainsKey(key))
                    {
                        
                        iSumOpen += rec.open;
                        
                    }
                    
                    else
                    {
                        vSummaryResults.Add(key, list);
                    }
                    
                }
                Console.WriteLine(iSumOpen);
            }
