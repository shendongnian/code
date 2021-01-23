        private static void JoinSample()
        {
            List<TransactionInformation> failures = ...
            List<MyHome> myHomeData = ...
            var joined =
                from f in failures // Iterate failures
                join d in myHomeData on // Join with myHomeData
                f.Username equals d.MyHomeUserName // when the username matches
                select new // store values in anonymous type
                {
                    MyHome = d,
                    Failure = f
                };
            foreach (var item in joined)
            {
                Console.WriteLine(item.MyHome.ToString());
                Console.WriteLine(item.Failure.ToString());
            }
        }
