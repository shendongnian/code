    string str1 = "S00009";
    string prefix = str1.Substring(0, 1); // get prefix
    string valueStr = str1.Substring(1); // get value
    int valueInt = -1; // initialize
    string strResult = string.Empty; // initialize
    if(int.TryParse(valueStr, out valueInt)) // if parse succeed
    {
       valueInt += 1; // Add 1
       strResult = string.Format("{0}{1:D5}", prefix, valueInt);
    }
    Console.WriteLine(strResult);
