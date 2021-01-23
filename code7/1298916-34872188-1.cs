            List<string> linesInFile = File.ReadLines("yourFile.csv").ToList();
            List<DateTime> passedDateList = new List<DateTime>();
            List<string> duplicateLines = new List<string>();
            foreach (var item in linesInFile)
            {
                //extract value for date
                string OldDate = (day + "/" + month + "/" + year);
                DateTime dt1 = DateTime.Parse(OldDate);
                if (passedDateList.Contains(dt1))
                {
                    duplicateLines.Add(item);
                    // the date is already passed
                }
                else
                {
                    // it is no yet passed 
                    //Do your task here
                    passedDateList.Add(dt1);
                }
            }
            linesInFile = linesInFile.Except(duplicateLines).ToList(); // remove already passed line
            File.WriteAllLines("yourFile.csv", linesInFile); // write back to the file
