    String line = "TTACCTTAAC";
    int k = 3; //this is variable but for simplicity is 3
    String _pattern = "";
    for (int i = 0; i <= line.Length - k; i++) {
        _pattern = line.Substring(i, k);
        //do something...
    }
