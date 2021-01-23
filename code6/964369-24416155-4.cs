        static public int[] SortCorrectedUserCode(int[] Source)
        {
            int[] Sublist,
                Results;
            int ItemsLeft,
                SublistPos,
                ResultPos;//new variable to store current pos in results
            //n; n was useless
            Sublist = new int[Source.Length];
            Results = new int[Source.Length];
            //Avoid resets just using an integer to track array lengths
            //Reset(ref Sublist);
            //Reset(ref Results);
            ItemsLeft = Source.Length;
            ResultPos = 0;
            while (ItemsLeft != 0)
            {
                //n = int.MinValue;
                SublistPos = 0;
                for (int currentSourcePos = 0; currentSourcePos < Source.Length; currentSourcePos++)
                {
                    if (Source[currentSourcePos] != int.MaxValue)
                    {
                        //Added special treatment for first item in sublist (copy it yes or yes ;D)
                        if (SublistPos == 0 || Source[currentSourcePos] > Sublist[SublistPos])
                        {
                            Sublist[SublistPos] = Source[currentSourcePos];
                            //n = Source[currentSourcePos]; useless
                            Source[currentSourcePos] = int.MaxValue;
                            ItemsLeft--;
                            SublistPos++;
                        }
                    }
                }
                //int p3p, zs;
                //pn is never true...
                //bool pn = false;
                //Sublist was being iterated for all it's length, not only for the current items
                //for (int currentSublistPos = 0; currentSublistPos < Sublist.Length; currentSublistPos++)
                for (int currentSublistPos = 0; currentSublistPos < SublistPos; currentSublistPos++)
                {
                    //p3p = int.MinValue;
                    bool inserted = false;
                    //Results was being iterated for all it's length, not only for current items
                    //for (int currentResultPos = 0; currentResultPos < Results.Length; currentResultPos++)
                    for (int currentResultPos = 0; currentResultPos < ResultPos; currentResultPos++)
                    {
                        //This part was never used...
                        //if (pn)
                        //{
                        //    zs = Results[currentResultPos];
                        //    Results[currentResultPos] = p3p;
                        //    p3p = zs;
                        //}
                        //else
                        //{
                        //This IF was wrong, when the code entered this piece of code it started
                        //for subsequent iterations in the current loop to copy data from sublist to list, which is not correct ... I think, not sure 
                        //because it's really confusing
                        //if (Sublist[currentSublistPos] >= p3p && Sublist[currentSublistPos] <= Results[currentResultPos])
                        //{
                        //p3p = Results[currentResultPos];
                        //Results[currentResultPos] = Sublist[currentSublistPos];
                        //}
                        //}
                        //New code, if the item at sublist is lower than the one at results then insert item in current position
                        if (Sublist[currentSublistPos] < Results[currentResultPos])
                        {
                            InsertInArray(currentResultPos, Sublist[currentSublistPos], Results);
                            inserted = true;
                            break;
                        }
                    }
                    //Did we inserted the item?
                    if (!inserted)
                        Results[ResultPos] = Sublist[currentSublistPos]; //If no then just add it to the end of the results
                    ResultPos++;
                }
                //Reset(ref Sublist);
            }
            return Results;
        }
        //Helper function to insert a value in an array and displace values to the right
        static void InsertInArray(int Index, int Value, int[] Target)
        {
            //Create temp array of right items
            int[] tempArray = new int[(Target.Length - Index) - 1];
            //Copy items to temp array
            Array.Copy(Target, Index, tempArray, 0, tempArray.Length);
            //Set value at index
            Target[Index] = Value;
            //Copy values from temp array to correct position
            Array.Copy(tempArray, 0, Target, Index + 1, tempArray.Length);
        
        }
