        /// <summary>
        /// In this method I use the lineCounter as my position tracker to know which line I'm readin at the time
        /// </summary>
        /// <param name="fileName"></param>
        public void ReWriteFileDontAffectFirstRow(string fileName)
        {
            int lineCounter = 0;//lets make our own position tracker
            using (StreamWriter sw = new StreamWriter(@"M:\StackOverflowQuestionsAndAnswers\38873875\38873875\testdata_new2.csv"))
            {
                string currentLine = string.Empty;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while ((currentLine = sr.ReadLine()) != null)//while there are lines to read
                    {
                        if (lineCounter != 0)
                        {
                            //If it's not the first line
                            string[] fielded = currentLine.Split(',');//split your fields into an array
                            fielded[4] = fielded[4].Replace(" ", ",");//replace the space in position 4(field 5) of your array
                            sw.WriteLine(string.Join(",", fielded));//write the line in the new file
                        }
                        else
                        {
                            //If it's the first line
                            sw.WriteLine(currentLine);//Write the line as-is
                        }
                        lineCounter++;
                    }
                }
            }
        }
