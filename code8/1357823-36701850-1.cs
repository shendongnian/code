    static void parse()
    {
        StreamReader sr = new StreamReader("sales.txt");
        //variables declared here
        string line = string.empty;
        double answer = 0;
        List<double> numbersTwo = new List<double>();
        //while loop that reads in the .txt file
        while ((line = sr.ReadLine()) != null)
        {
            if (line != null)
            {
                foreach (string num in line.Split(',');)
                {
                    numbersTwo.Add(double.Parse(num));
                }
            }
        }
    }
