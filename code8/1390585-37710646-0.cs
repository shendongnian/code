    public static string Test1(params string[] input)
    {
        return input
            .Where(x => x == "apples") // empty enumerable, because no item matches "apples"
            .DefaultIfEmpty("not found") // {"not found"}, since the enumerable is empty
            .First(); //"not found", since we have this item
    } 
    public static string Test2(params string[] input)
    {
        return input
            .DefaultIfEmpty("not found") // { "oranges", "pears", "pineapples" }
                                         //i.e., nothing changes, because input is not empty
            .First(x => x == "apples"); //Exception because there is no
                                        //item that is equal to "apples"
    }
