    string min = "2.s"; // not a number
    double finals;
    bool successed =  double.TryParse(min, out finals); // true if successed, otherwise false.
    Console.WriteLine(successed? $"Yes! finals =  {finals}": $"No :( finals =  {finals}");
    // finals is 0 if the parse didn't work.
