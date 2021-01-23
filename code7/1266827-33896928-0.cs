    public string campDiff(string lineStr1, string lineStr2)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int size;
        string sum = null;
        double num1;
        double num2;
        double number;
        string[] lineArr1 = lineStr1.Split(' '); ;
        string[] lineArr2 = lineStr2.Split(' ');
        if (lineArr1.Length > lineArr2.Length)
        {
            size = lineArr1.Length;
        }
        else
        {
            size = lineArr2.Length;
        }
        for (int i = 0; i < size; i++)
        {
            if (Double.TryParse(lineArr1[i].Replace(",", "."), out num1))
            {
                if (Double.TryParse(lineArr2[i].Replace(",", "."), out num2))
                {
                    number = num2 - num1;
                    if (number > 0)
                    {
                        sum = Convert.ToString(number);
                        return sum;
                    }
                }
            }
        }
        return sum;
    }
