    dictionary.Add("42", 42);      
    dictionary.Count();            // 3
    dictionary.ContainsKey("3");   // false
    dictionary.ContainsValue(230); // true
    dictionary.Remove("230");
    dictionary.Count();            // 2
    dictionary.Clear();
    dictionary.Count();            // 0
