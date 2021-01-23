    string skaiciai = "skaiciai.txt";
  
    string[] lines = File.ReadAllLines(skaiciai); // use this to read all text line by line into array of string
    List<int> numberList = new List<int>(); // use list of instead of array when length is unknown
    for (int i = 0; i < lines.Length; i++)
    {
        string[] line = lines[i].Split(' ');
        for (int j = 0; j < line.Length; j++)
        {
            string number = line[j];
            int n;
            if (int.TryParse(number, out n)) // try to parse string into integer
            {
                numberList.Add(n); // add numbers into list
            }
        }
    }
    int totalNumbers = numberList.Count;
    long sum = numberList.Sum();
    long product = numberList.Aggregate((a, b) => a*b);
    int min = numberList.Min();
    int max = numberList.Max();
    double average = sum/(double)totalNumbers;
