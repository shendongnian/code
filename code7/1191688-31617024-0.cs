    [Flags]
    enum People
    {
        None = 0x0, Adam = 0x1, Barry = 0x2, Chris = 0x4, David = 0x8, 
        Eric = 0x10, Frank = 0x20, George = 0x40, Harold = 0x80, Ian = 0x100, 
        Joe = 0x200, Larry = 0x400, Mark = 0x800, Nathan = 0x1000, Oscar = 0x2000, 
        Paul = 0x4000, Roger = 0x8000, Sam = 0x10000, Tom = 0x20000, 
        Victor = 0x40000, Walter = 0x80000,Yogi = 0x100000, Zane = 0x200000
    };
    
    Dictionary<string, People> EUInterest = new Dictionary<string, People>() { 
    { "athletes", People.Adam | People.Barry }, 
    { "artists", People.Frank | People.Harold } };
    Dictionary<string, People> USInterest = new Dictionary<string, People>() { 
    { "athletes", People.Chris | People.Harold }, 
    { "artists", People.Eric } };
    
    var query = from interest in EUInterest.Keys
                    where USInterest.ContainsKey(interest)
                    let v1 = EUInterest[interest]
                    let v2 = USInterest[interest]
                    select new Dictionary<string, People>() { {interest, v1 | v2 } };
    
    Dictionary<string, People> temp = new Dictionary<string, People>();
    foreach (var a in query)
    {
        temp = temp.MergeLeft(a);
    }
    
    foreach (People option in Enum.GetValues(typeof(People)))
    {
        if (temp["athletes"].HasFlag(option))
            Console.WriteLine("{0} IS AN ATHLETE.", option);
        // else Console.WriteLine("{0} is not an athlete.", option);
    }
