    public class StrandSort
    {
        public static int[] SortWithGenerics(int[] Values)
        {
            List<int> Original = new List<int>();
            List<int> Result = new List<int>();
            List<int> Sublist = new List<int>();
            Original.AddRange(Values);
            //While we still have numbers to sort
            while (Original.Count > 0)
            {
                //Clear sublist and take first available number from original to the new sublist
                Sublist.Clear();
                Sublist.Add(Original[0]);
                Original.RemoveAt(0);
                //Iterate through original numbers
                for (int x = 0; x < Original.Count; x++)
                {
                    //If the number is bigger than the last item in the sublist
                    if (Original[x] > Sublist[Sublist.Count - 1])
                    {
                        //Add it to the sublist and remove it from original
                        Sublist.Add(Original[x]);
                        Original.RemoveAt(x);
                        //Roll back one position to compensate the removed item
                        x--;
                    }
                }
                //If this is the first sublist
                if (Result.Count == 0)
                    Result.AddRange(Sublist); //Add all the numbers to the result
                else
                {
                    //Iterate through the sublist
                    for (int x = 0; x < Sublist.Count; x++)
                    {
                        bool inserted = false;
                        //Iterate through the current result
                        for (int y = 0; y < Result.Count; y++)
                        {
                            //Is the sublist number lower than the current item from result?
                            if (Sublist[x] < Result[y])
                            {
                                //Yes, insert it at the current Result position
                                Result.Insert(y, Sublist[x]);
                                inserted = true;
                                break;
                            }
                        }
                        //Did we inserted the item because found it was lower than one of the result's number?
                        if (!inserted)
                            Result.Add(Sublist[x]);//No, we add it to the end of the results
                    }
                }
            }
            //Return the results
            return Result.ToArray();
        }
        public static int[] SortWithoutGenerics(int[] Values)
        {
            IntLinkedList Original = new IntLinkedList();
            IntLinkedList Result = new IntLinkedList();
            IntLinkedList Sublist = new IntLinkedList();
            Original.AddRange(Values);
            //While we still have numbers to sort
            while (Original.Count > 0)
            {
                //Clear sublist and take first available number from original to the new sublist
                Sublist.Clear();
                Sublist.Add(Original.FirstItem.Value);
                Original.Remove(Original.FirstItem);
                
                IntLinkedItem currentOriginalItem = Original.FirstItem;
                //Iterate through original numbers
                while (currentOriginalItem != null)
                {
                    //If the number is bigger than the last item in the sublist
                    if (currentOriginalItem.Value > Sublist.LastItem.Value)
                    {
                        //Add it to the sublist and remove it from original
                        Sublist.Add(currentOriginalItem.Value);
                        //Store the next item
                        IntLinkedItem nextItem = currentOriginalItem.NextItem;
                        //Remove current item from original
                        Original.Remove(currentOriginalItem);
                        //Set next item as current item
                        currentOriginalItem = nextItem;
                    }
                    else
                        currentOriginalItem = currentOriginalItem.NextItem;
                }
                //If this is the first sublist
                if (Result.Count == 0)
                    Result.AddRange(Sublist); //Add all the numbers to the result
                else
                {
                    IntLinkedItem currentSublistItem = Sublist.FirstItem;
                    
                    //Iterate through the sublist
                    while (currentSublistItem != null)
                    {
                        bool inserted = false;
                        IntLinkedItem currentResultItem = Result.FirstItem;
                        //Iterate through the current result
                        while (currentResultItem != null)
                        {
                            //Is the sublist number lower than the current item from result?
                            if (currentSublistItem.Value < currentResultItem.Value)
                            {
                                //Yes, insert it at the current Result position
                                Result.InsertBefore(currentResultItem, currentSublistItem.Value);
                                inserted = true;
                                break;
                            }
                            currentResultItem = currentResultItem.NextItem;
                        }
                        //Did we inserted the item because found it was lower than one of the result's number?
                        if (!inserted)
                            Result.Add(currentSublistItem.Value);//No, we add it to the end of the results
                        currentSublistItem = currentSublistItem.NextItem;
                    }
                }
            }
            //Return the results
            return Result.ToArray();
        }
        public class IntLinkedList
        {
            public int count = 0;
            IntLinkedItem firstItem = null;
            IntLinkedItem lastItem = null;
            public IntLinkedItem FirstItem { get { return firstItem; } }
            public IntLinkedItem LastItem { get { return lastItem; } }
            public int Count { get { return count; } }
            public void Add(int Value)
            {
                if (firstItem == null)
                    firstItem = lastItem = new IntLinkedItem { Value = Value };
                else
                { 
                
                    IntLinkedItem item = new IntLinkedItem{  PreviousItem = lastItem, Value = Value };
                    lastItem.NextItem = item;
                    lastItem = item;
                
                }
                count++;
            
            }
            public void AddRange(int[] Values)
            {
                for (int buc = 0; buc < Values.Length; buc++)
                    Add(Values[buc]);
            
            }
            public void AddRange(IntLinkedList Values)
            {
                IntLinkedItem item = Values.firstItem;
                while (item != null)
                {
                    Add(item.Value);
                    item = item.NextItem;
                
                }
            }
            public void Remove(IntLinkedItem Item)
            {
                if (Item == firstItem)
                    firstItem = Item.NextItem;
                if (Item == lastItem)
                    lastItem = Item.PreviousItem;
                if(Item.PreviousItem != null)
                    Item.PreviousItem.NextItem = Item.NextItem;
                if (Item.NextItem != null)
                    Item.NextItem.PreviousItem = Item.PreviousItem;
                count--;
            
            }
            public void InsertBefore(IntLinkedItem Item, int Value)
            {
                IntLinkedItem newItem = new IntLinkedItem { PreviousItem = Item.PreviousItem, NextItem = Item, Value = Value };
                if (Item.PreviousItem != null)
                    Item.PreviousItem.NextItem = newItem;
                Item.PreviousItem = newItem;
                if (Item == firstItem)
                    firstItem = newItem;
                count++;
            }
            public void Clear()
            {
                count = 0;
                firstItem = lastItem = null;
            
            }
            public int[] ToArray()
            {
                int[] results = new int[Count];
                int pos = 0;
                IntLinkedItem item = firstItem;
                while (item != null)
                {
                    results[pos++] = item.Value;
                    item = item.NextItem;
                }
                return results;
            
            }
        }
        public class IntLinkedItem
        { 
        
            public int Value;
            internal IntLinkedItem PreviousItem;
            internal IntLinkedItem NextItem;
        
        }
    }
