    string format(string column1, string column2, string column3)
        {
            int column1Width = 4;
            int column2Width = 10;
            int column3Width = 5;
            int loopCount = 0;
            StringBuilder output = new StringBuilder();
            while (true)
            {
                string col1 = new string(column1.Skip<char>(loopCount * column1Width).Take<char>(column1Width).ToArray()).PadRight(column1Width);
                string col2 = new string(column2.Skip<char>(loopCount * column2Width).Take<char>(column2Width).ToArray()).PadRight(column2Width);
                string col3 = new string(column3.Skip<char>(loopCount * column3Width).Take<char>(column3Width).ToArray()).PadRight(column3Width);
                //Break out of loop once all col variables contain only white space
                if (String.IsNullOrWhiteSpace(col1) && String.IsNullOrWhiteSpace(col2) && String.IsNullOrWhiteSpace(col3))
                {
                    break;
                }
                output.AppendFormat("{0} {1} {2}\n", col1, col2, col3);
                loopCount++;
            }
            return output.ToString();
        }
