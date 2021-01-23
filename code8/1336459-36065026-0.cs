    string s = "One";
    var numbers = list.Where(x => x == s || !string.IsNullOrEmpty(x));
    foreach(var number in numbers)
    {
       Console.WriteLine(number);
       // output:
       // One <-- First condition is met
       // Two <-- First condition is not met so goes into the OR operator and returns true
       // Three <--Same as above
    }
