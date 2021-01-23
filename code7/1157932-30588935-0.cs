    public void PrintLog(IList<TimeSpan> timeList, string logFileName)
    {
        int count = timeList.Count;
    
        if (count != 0)
        {
            using (FileStream fs = new FileStream(logFileName, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    int beginIndex = 0;
                    int beginSecond = timeList[0].Seconds;
    
                    for (int i = 0; i < count; i++)
                    {
                        if (timeList[i].Seconds == beginSecond + 1)
                        {
                            // end of interval
                            sw.WriteLine("{0} - {1}", timeList[beginIndex], timeList[i]);
                            beginIndex = i + 1;
                            if (i < count - 1)
                            {
                                beginSecond = timeList[i + 1].Seconds;
                            }
                        }
                        else if (timeList[i].Seconds > beginSecond + 1)
                        {
                            // new interval
                            sw.WriteLine("{0} - {1}", timeList[beginIndex], timeList[beginIndex]);
                            beginIndex = i;
                            beginSecond = timeList[i].Seconds;
                        }
                    }
    
                    if (beginIndex <= count - 1)
                    {
                        // last interval
                        sw.WriteLine("{0} - {1}", timeList[beginIndex], timeList[count - 1]);
                    }
                }
            }
        }
    }
