    List<int> myList = new List<int>();
    myList.Add(100);
    myList.Add(200);
    myList.Add(300);
    myList.Add(400);
    myList.Add(200);
    myList.Add(500);
    var result = new List<List<int>>();
    var skip = 0;
    while (skip < myList.Count)
    {
        var sum = 0;
        result.Add(myList.Skip(skip).TakeWhile(x =>
        {
            sum += x;
            return sum <= 600;
        }).ToList());
        skip += result.Last().Count();
    }
