       public class TransactionData
        {
            private Dictionary<string, List<string>> transactionsAndFilesDictionary = new Dictionary<string, List<string>>();
            public bool FileBlocked(string transactionID, string fileName)
            {
                foreach (var key in this.transactionsAndFilesDictionary.Keys)
                {
                    if (transactionsAndFilesDictionary[key].Where(x => x.Contains(fileName)).Count() > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }​
