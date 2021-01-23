    class SummedKV
    {
        public KeyValuePair Kvp {get; set;}
        public int Sum {get; set;}
    }
    var myList  =
             myDic.ToList()
                  .Select(kvp=> new SummedKV {Kvp = kvp, Sum = kvp.Value.Sum() });
    myList.Sort(skv=>skv.Sum);
