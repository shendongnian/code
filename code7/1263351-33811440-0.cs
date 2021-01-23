        private List<int> getTimeGapIndexEndPoints(double maxTimeGapSeconds)
        {
            int x = 1;
            List<int> timeLapsIndexes = new List<int>();
            for (int i = 0; i < trackerData[trackerId].currentList.Count(); i++)
            {
                if (x < trackerData[trackerId].currentList.Count())
                {
                    DateTime t1 = trackerData[trackerId].currentList[i].TimeStamp;
                    DateTime t2 = trackerData[trackerId].currentList[x++].TimeStamp;
                    TimeSpan duration = t2.Subtract(t1);
                    if (duration.TotalSeconds > maxTimeGapSeconds)
                    {
                        // MessageBoxResult resultb = System.Windows.MessageBox.Show(this, "After index: "+i+" "+duration+" Duration for trackerId: " + trackerId + " exceed " + maxTimeGapSeconds);
                        timeLapsIndexes.Add(i);
                    }
                }
            }
            return timeLapsIndexes;
            //for (int j = 0; j < timeLapsIndexes.Count(); j++)
            //{
            //    MessageBoxResult resultNumbers = System.Windows.MessageBox.Show(this, "After Index (i+1): " + timeLapsIndexes[j] + " for trackerId: " + trackerId);
            //}
        }
