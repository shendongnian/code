        using System.Collections.Concurrent; using System.Threading;
        private static ConcurrentBag<String> items = new ConcurrentBag<String>();
        private static List<String> searchStrings;
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(csvFile))
            {
                const int buffer_size = 10000;
                string[] buffer = new string[buffer_size];
                int count = 0;
                String line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    buffer[count] = line;
                    count++;
                    if (count == buffer_size)
                    {
                        new Thread(() =>
                            {
                                find(buffer);
                            }).Start();
                        buffer = new String[buffer_size];
                        count = 0;
                    }
                }
                if (count > 0)
                {
                    find(buffer);
                }
                //some kind of sync here, can be done with a bool - make sure all the threads have finished executing
                foreach (var str in searchStrings)
                    streamWriter.write(str);
            }
        }
        private static void find(string[] buffer)
        {
            //do your search algorithm on the array of strings
           //add to the concurrentbag if they match
        }
