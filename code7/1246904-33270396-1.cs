    string skaiciai = "skaiciai.txt";
  
    string[] lines = File.ReadAllLines(skaiciai); // use this to read all text line by line into array of string
    List<int> numberList = new List<int>(); // use list of instead of array when length is unknown
    for (int i = 0; i < lines.Length; i++)
    { 
        //if (s == string.Empty) continue; // No need to check for that. Split method returns empty array so you will never go inside inner loop.
         
        string[] line = lines[i].Split(' ');
        for (int j = 0; j < line.Length; j++)
        {
            string number = line[j];
            int n;
            if (int.TryParse(number, out n)) // try to parse string into integer. returns true if succeed.
            {
                numberList.Add(n); // add converted number into list
            }
        }
    }
    int totalNumbers = numberList.Count;
    int sum = numberList.Sum();
    int product = numberList.Aggregate((a, b) => a*b);
    int min = numberList.Min();
    int max = numberList.Max();
    double average = sum/(double)totalNumbers;
