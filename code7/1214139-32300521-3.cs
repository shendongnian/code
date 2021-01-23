        /// <summary>
        /// Courtesty of : http://stackoverflow.com/a/24016130/5282506
        /// Adapted by me.
        /// 
        /// Pass in the unique symbol and itll find the first and last index pairs
        /// Can adapt to find all unique pairs at once.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="searchstring">The searchstring letter (b, i, etc)</param>
        /// <returns></returns>
    public static IEnumerable<int> AllIndexesOf(string str, string searchstring)
    {
        //assumes the string is formatted correctly. Only one tag of the same type inside each tag.
    
        int minIndex = str.IndexOf("["+searchstring+"]");
        while (minIndex != -1)
        {
            Console.WriteLine("First: {0}", minIndex);
            yield return minIndex;
            var maxIndexEnd = str.IndexOf("[/"+ searchstring +"]", minIndex + searchstring.Length +3);//added three for the [/ and ] characters.
            Console.WriteLine("End: {0}", maxIndexEnd);
    
            if (maxIndexEnd == -1)
            {
                //Malformed string, no end element for a found start element
                //Do something...
                throw new FormatException("Malformed string");
            }
            yield return maxIndexEnd;
            minIndex = str.IndexOf("[" + searchstring+"]", maxIndexEnd + searchstring.Length+2);//added two for the [ and ] characters
        }
    }
