        public int SublistIndex(string[] lookInThis, string[]lookForThis)
        {
            int i;
            for (i = 0; i < lookInThis.Count(); i++)
            {
                if (lookInThis.ElementAt(i).Equals(lookForThis.First()))
                {
                    //Found the first element of the list we are searching for
                    int j;
                    for (j = 0; j < lookForThis.Count(); j++)
                    {
                        if (i + j == lookInThis.Count())
                        {
                            //Reached the end of the lookInThis list with no match
                            return -1;
                        }
                        if (!lookInThis.ElementAt(i + j).Equals(lookForThis.ElementAt(j)))
                        {
                            //Sequence is not identical, stop looping
                            break;
                        }
                    }
                    if (j == lookForThis.Count())
                    {
                        //found it!
                        return i;
                    }
                }
            }
            //reached the end and didn't find it
            return -1;
        }
