    string pattern = "Hello Scott, welcome to VietNam";
        
    var splitsArray = pattern.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    var Name = splitsArray[1].Replace(",", string.Empty);
    var country = splitsArray[4];
