    static void Main(string[] args)
        {
            List<int> data = new List<int> { 1, 2, 1, 2, 3, 3, 1, 2, 3, 4, 1, 2, 3, 4, 5, 6 };
            Dictionary<int, List<int>> listDict = new Dictionary<int, List<int>>();
            int listCnt = 1;
            //as initial value get first value from list
            listDict.Add(listCnt, new List<int>());
            listDict[listCnt].Add(data[0]);
            
            for (int i = 1; i < data.Count; i++)
            {
                 if (data[i] > listDict[listCnt].Last())
                {
                    listDict[listCnt].Add(data[i]);
                }
                 else
                {
                    //increase list count and add a new list to dictionary
                    listCnt++;
                    listDict.Add(listCnt, new List<int>());
                    listDict[listCnt].Add(data[i]);
                }
            }
            //to use new lists
            foreach (var dic in listDict)
            {
                Console.WriteLine( $"List {dic.Key} : " + string.Join(",", dic.Value.Select(x => x.ToString()).ToArray()));
                
            }
        }
