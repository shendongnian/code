        public string[] SplitLine(string line, int numberOfCharacters)
        {
            if (line.Length < numberOfCharacters)
                return new [] { line }; // no splitting necessary
            string[] result = new string[2]; // only two lines needed
            int splitPoint = numberOfCharacters; // the position to split at if it is a white space
            // if it is not a white space, iterate the splitPoint down until you reach a white space character
            while (splitPoint >= 0 && line[splitPoint] != ' ')
                splitPoint--;
            
            //return the two lines
            result[0] = line.Substring(0, splitPoint);
            result[1] = line.Substring(splitPoint, line.Length - splitPoint);
            return result;
        }
