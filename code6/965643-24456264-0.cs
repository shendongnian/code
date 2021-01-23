    List<int> ints = new List<int>()
    {
         1,2,5,8,12,34,12,52,34
    };
    
    int NthLargest = 1;
    var queryresult = ints
                       .GroupBy(e => e)
                       .OrderByDescending(f => f.Key)
                       .Skip(NthLargest == 0?0:NthLargest - 1)//if by some weird case someone puts 0 lol
                       .First();
