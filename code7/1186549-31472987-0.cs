    static List<List<int>> SplitFileWithLimitSize(List<int> totalSizes, int limitSize)
    {
        List<List<int>> resultList = new List<List<int>>();//the result packet
        List<int> tmp = new List<int>();
        int reduceSize = limitSize;
        while (true)
        {
            var maxSize = totalSizes.Where(x => x <= reduceSize).FirstOrDefault();
            if (maxSize == 0)
            {
                resultList.Add(tmp);
                tmp = new List<int>();
                reduceSize = limitSize;
                continue;
            }
            reduceSize = reduceSize - maxSize;
            totalSizes.Remove(maxSize);
            tmp.Add(maxSize);
            if (totalSizes.Count == 0)
            {
                resultList.Add(tmp);
                break;
            }
        }
        //resultList.ForEach(x =>
        //{
        //    Console.WriteLine("Pack:" + string.Join(" ", x));
        //});
        return resultList;
    }
