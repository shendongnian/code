     //Find largest in tempRankingData
    int largestIntempRankingData = tempRankingData[0, 0];
    List<KeyValuePair<double,string>> list = new List<KeyValuePair<double,string>>();
    for (int i = 0; i < count; i++)
    {
        for (int j = 0; j < count; j++)
        {
            if (tempRankingData[i, j] > largestIntempRankingData)
            {
                largestIntempRankingData = tempRankingData[i, j];
                list.Add(new KeyValuePair<double, string>(largestIntempRankingData, i + "," + j));   //Add the value and the position;
            }
        }
    }
    
    //This gives a list of strings in which hold the position of largestInItemRankingData example "3,3"
                //Only positions where the key is equal to the largestIntempRankingData;
    list.Where(w => w.Key == largestIntempRankingData).ToList().Select(s => s.Value).ToList(); 
