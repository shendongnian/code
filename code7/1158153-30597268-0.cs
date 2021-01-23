    //Find largest in each column
    int largestInColumn = 0;
    int largestOverall = 0;
    List<string> positionOfLargestInColumn;
    Dictionary<int, List<string>> position = new Dictionary<int, List<string>>();
    List<string> positionLargestIntempRankingData = new List<string>();
    for (int i = 0; i < count; i++)
    {
        largestInColumn = tempRankingData[0, i];
        positionOfLargestInColumn = new List<string>();
        positionOfLargestInColumn.Add("0," + i);
        for (int j = 1; j < count; j++)
        {
            if (tempRankingData[j, i] > largestInColumn)
            {
                largestInColumn = tempRankingData[j, i];
                positionOfLargestInColumn.Clear();
                positionOfLargestInColumn.Add(j + "," + i);
            }
            else if(tempTankingData[j,i] == largestInColumn)
            {
                positionOfLargestInColumn.Add(j + "," + i);
            }
        }
        position.Add(i, positionOfLargestInColumn);
        if(largestInColumn > largestOverall)
        {
          positionLargestIntempRankingData.Clear();
          positionLargestIntempRankingData.AddRange(positionOfLargestInColumn);
          largestOverall = largestInColumn;
        }
        else if(largestInColumn == largestOverall)
        {
          positionLargestIntempRankingData.AddRange(positionOfLargestInColumn);
        }
    }
