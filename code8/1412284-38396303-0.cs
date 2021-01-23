        static void Main(string[] args)
        {
            ConcurrentDictionary<string, int> results = new ConcurrentDictionary<string, int>();
            string[] connStrings = new string[]{"connstring1", "connstring2"};
            Parallel.For(0, connStrings.Length, (i) => {
                results[connStrings[i]] = TryToConnectToDatabase(connStrings[i]);
            });
        }
        static int TryToConnectToDatabase(string connstr)
        {
            try
            {
                OleDbConnection con1;
                using (con1 = new OleDbConnection(connstr))
                {
                    con1.Open();
                    con1.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
