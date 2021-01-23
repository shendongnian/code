    string text = "Foo 1234 Test Bah344 ....";
    int index = text.LastIndexOfAny("0123456789".ToCharArray());
    if(index >= 0)
    {
        string until = text.Substring(0, index + 1);
        var digits = until.Reverse().TakeWhile(char.IsDigit).Reverse();
        string lastNumber = new string(digits.ToArray());  // 344
    }                 
