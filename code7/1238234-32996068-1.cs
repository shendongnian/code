    class GetSetPair<T> 
    {
        public Func<T> Get {get;set;}
        public Action<T> Set {get;set;}
    }
    var referencesToInt = new List<GetSetPair<int>>();
   
    int value = 42;
    referencesToInt.Add(new GetSetPair<int>{Get=()=>value, Set = v => value = v});
    referencesToInt[0].Set(33);
    Console.WriteLine(value); // 33
    value = 22;
    Console.WriteLine(referencesToInt[0].Get()); //22
