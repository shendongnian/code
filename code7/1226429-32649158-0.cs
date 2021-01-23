    string value = "bananas";
    string[] arr = 
    {
        "I like bananas", 
        "I like apples",
        "I like cherries",
        "I like bananas",
        "I like apples"
    };
    Console.WriteLine(Array.FindLastIndex(arr, x => x.Contains(value)));
