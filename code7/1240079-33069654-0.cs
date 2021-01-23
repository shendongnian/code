    public static void ConvertToSRTSubs()
        {
            byte [] openingTimeWindow = Encoding.ASCII.GetBytes("["); \\Timespan in the binary is wrapped around square brackets
            byte [] nextOpening = Encoding.ASCII.GetBytes("[00"); \\ I need this as a point to get the end of the sentence, because there is a fixed size between sentences and next timespan.
            byte [] closingTimeWindow = Encoding.ASCII.GetBytes("]"); \\End of the timespan
            int found = 0;  \\This will iterate through every timespan match
            int backPos = 0; \\Pointer to the first occurrence
            int nextPos = 0;
            int sentenceStartPos = 0;
            int newStartFound = 0;
            string srtTime = String.Empty;
            string srtSentence = String.Empty;
            byte[] array = File.ReadAllBytes(Path.Combine(coursePath, hashedSubFileName));
            try
            {
                using (StreamWriter s = new StreamWriter(Video.outPath + ext, false))
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (openingTimeWindow[0] == array[i] && closingTimeWindow[0] == array[i + 12])
                        {
                            found++;
                            s.WriteLine(found);                            
                            try
                            {
                                backPos = i;
                                for (i = backPos + 12; i < array.Length; i++ )
                                    {
                                        if (newStartFound == 1) 
                                            break;
                                        if (nextOpening[0] == array[i] && nextOpening[1] == array[i + 1] && nextOpening[2] == array[i + 2])
                                        {
                                            nextPos = i - 19;
                                            newStartFound++;
                                        }
                                    }
                                i = backPos;
                                newStartFound = 0;
                                sentenceStartPos = backPos + 27;
                                sentenceSize = nextPos - sentenceStartPos;
                                if (sentenceSize < 0) sentenceSize = 1;
                                byte[] startTime = new byte[11];
                                byte[] sentence = new byte[sentenceSize];
                                Array.Copy(array, backPos + 1, startTime, 0, 11);
                                Array.Copy(array, sentenceStartPos, sentence, 0, sentenceSize);
                                srtTimeRaw = srtTime = Encoding.UTF8.GetString(startTime);
                                srtTime = srtTimeRaw.Replace('.', ',') + "0" + " --> " + span;
                                s.WriteLine(srtTime);
                                srtSentence = Encoding.UTF8.GetString(sentence);
                                s.WriteLine(srtSentence);
                                s.WriteLine();
                            }
                            catch (ArgumentException argex)
                            {
                                MessageBox.Show(argex.ToString());
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException dex)
            {
                MessageBox.Show(dex.ToString());
            }
        }
