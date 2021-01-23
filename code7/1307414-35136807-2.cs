     public class MultiDimDictList: Dictionary<string, List<int>>  { }
     MultiDimDictList myDictList = new MultiDimDictList ();
     Foreach (string value in distinctSessionID)
    {
         myDictList.Add(value, new List<int>()); 
         for(int j=0; j < lengthofLines; j++)
         {
             myDictList[value].Add(myLine);
         }
    }
