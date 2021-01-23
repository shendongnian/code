    public void PrintLog(IList<TimeSpan> timeList, TimeSpan frameTime, string logFileName)
    {
        int count = timeList.Count;
        if (count != 0)
        {
            using (FileStream fs = new FileStream(logFileName, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    int beginIndex;
                    TimeSpan begin = timeList[beginIndex = 0];
                    for (int i = 1; i < count; i++)
                    {
                        if (timeList[i] - begin > frameTime)
                        {
                            sw.WriteLine("{0} - {1}", begin, timeList[i - 1]);
                            begin = timeList[beginIndex = i];
                        }
                    }
    
                    // last interval
                    if (beginIndex <= count - 1)
                    {
                        sw.WriteLine("{0} - {1}", timeList[beginIndex], timeList[count - 1]);
                    }
                }
            }
        }
    }
