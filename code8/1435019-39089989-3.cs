    byte[] data1 = { 54, 87, 23, 87, 45, 67, 7, 85, 65, 65, 3, 4, 55, 76, 65, 64, 5, 6, 4, 54, 45, 6, 4 };
    byte[] data2 = { 76, 57, 65, 3, 4, 55, 76, 65, 64, 5, 6, 4, 54, 45, 8, 65, 66, 57, 6, 7, 7, 56, 6, 7, 44, 57, 8, 76, 54, 67 };
    var indexes1 = index(data1);
    var indexes2 = index(data2);
    var bestIndex = 0;
    var bestCount = 0;
    for (var b = 0; b < 256; b++)
    {
        var list1 = indexes1[b]; if (list1 == null) continue;
        var list2 = indexes1[b]; if (list2 == null) continue;
        foreach(var index1 in list1)
        {
            foreach (var index2 in list2)
            {
                // your code here 
                for (var i1 = index1; i1 < data1.Length - bestCount; i1++)
                {
                    var currentCount = 0;
                    for (var i2 = index2; i2 < data2.Length; i2++)
                    {
                        if (data1[i1 + currentCount] == data2[i2])
                        {
                            currentCount++;
                            if (i1 + currentCount == data1.Length)
                            {
                                bestCount = currentCount;
                                bestIndex = i1;
                                break;
                            }
                        }
                        else
                        {
                            if (currentCount > bestCount)
                            {
                                bestCount = currentCount;
                                bestIndex = i1;
                            }
                            currentCount = 0;
                        }
                    }
                    if (currentCount > bestCount)
                    {
                        bestCount = currentCount;
                        bestIndex = i1;
                    }
                }
            }
        }
    }
    var best = data1.Skip(bestIndex).Take(bestCount);
    Debug.Print(bestIndex + ", " + bestCount + ": " + string.Join(", ", best));
