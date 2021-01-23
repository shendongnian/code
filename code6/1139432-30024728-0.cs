        private static void StartSimilarityCheck(List<string> whiteList)
        {
            var watch = Stopwatch.StartNew();
            for (int j = 0; j < whiteList.Count - 1; j++)
            {
                string dirName = whiteList[j];
                bool insertDirName = true;
                int threshold = 2;
                if (!IsBlackList(dirName))
                {
                    // start the next element
                    for (int i = j + 1; i < whiteList.Count; i++)
                    {
                        // end of index reached
                        if (i == whiteList.Count)
                        {
                            break;
                        }
                        int similiarity = LevenshteinDistance.Compute(dirName, whiteList[i]);
                        if (similiarity >= threshold)
                        {
                            break;
                        }
                        // low score means high similarity
                        if (similiarity <= threshold)
                        {
                            if (insertDirName)
                            {
                                AddSimilarEntry(dirName);
                                AddSimilarEntry(whiteList[i]);
                                AddBlackListEntry(whiteList[i]);
                                insertDirName = false;
                            }
                            else
                            {
                                AddBlackListEntry(whiteList[i]);
                            }
                        }
                    }
                }
                Console.WriteLine(j);
            }
            watch.Stop();
            Console.WriteLine("Ms: " + watch.ElapsedMilliseconds);
            Console.WriteLine("Similar entries: " + similar.Count);
        }
