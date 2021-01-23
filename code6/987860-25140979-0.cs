    class Program
    {
        static void Main(string[] args)
        {
            var populatedList = new List<String>
            {
                "One", "Two", "Three", "Four", "Five",
                "Six", "Seven", "Eight", "Nine", "Ten"
            };
            var fillThisList = new List<String>();
            int itr = 1;
            int keep = 3;
            int skip = 7;
            foreach (var item in populatedList)
            {
                if (itr == skip)
                {
                    // reset the iterator
                    itr = 1;
                    continue;
                }
                if (itr <= keep)
                {
                    fillThisList.Add(item);
                }
                itr++;
            }
        }
    }
