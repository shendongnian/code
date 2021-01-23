    Sample Code:
    
        public class StringsTest
        {
        private int i, maxValue = 500000000;
        string myString = "test";
        public long CompareToEmptyQuotes()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            for (i = 0; i < maxValue; i++)
            {
                if (myString == "")
                {
                    ;
                }
            }
            sw.Stop();
            Debug.WriteLine("Elpased Time: {0}", sw.ElapsedMilliseconds);
            return sw.ElapsedMilliseconds;
        }
        public long CompareToEmptyString()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            for (i = 0; i < maxValue; i++)
            {
                if (myString == string.Empty)
                {
                    ;
                }
            }
            sw.Stop();
            Debug.WriteLine("Elpased Time: {0}", sw.ElapsedMilliseconds);
            return sw.ElapsedMilliseconds;
        }
        }
