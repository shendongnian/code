        private void BuildGeoInfo()
        {
            string textFilePath = @"path to your text file";
            //Read all the contents of file as list of lines
            var fileLines = System.IO.File.ReadAllLines(textFilePath).ToList();
            //This list will hold the Latitude and Longitude iformation in pairs
            List<Tuple<double, double>> latLongInfoList = new List<Tuple<double, double>>();
            int index = 0;
            while (index < fileLines.Count)
            {
                var latLongInfo = new Tuple<double, double>(
                                      Convert.ToDouble(fileLines[index]), 
                                      Convert.ToDouble(fileLines[index++]));
                latLongInfoList.Add(latLongInfo);
                index++;
            }
        }
