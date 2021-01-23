        public void ReWriteFileAdjustHeaderRecordToo(string fileName)
        {
            int lineCounter = 0;//lets make our own position tracker
            using (StreamWriter sw = new StreamWriter(@"M:\StackOverflowQuestionsAndAnswers\38873875\38873875\testdata_new3.csv"))
            {
                string currentLine = string.Empty;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while ((currentLine = sr.ReadLine()) != null)//while there are lines to read
                    {
                        List<string> fielded = new List<string>(currentLine.Split(','));//splits your fields into a list of fields. This is no longer a string[]. Its a list so we can "inject" the new column in the header record.
                        if (lineCounter != 0)
                        {
                            //If it's not the first line
                            fielded[4] = fielded[4].Replace(" ", ",");//replace the space in position 4(field 5) of your array
                            sw.WriteLine(string.Join(",", fielded));//write the line in the new file
                        }
                        else
                        {
                            //If it's the first line
                            fielded.Insert(4, "new inserted col");//inject the new column into the list
                            sw.WriteLine(string.Join(",", fielded));//write the line in the new file
                        }
                        lineCounter++;
                    }
                }
            }
        }
