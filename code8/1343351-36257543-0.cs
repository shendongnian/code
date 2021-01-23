    double[] arr = new double[] { 0.0000074, 0.00000123, 0.0000001254 };
    using (StreamWriter writer = new StreamWriter(@"D:\Test.csv"))
    {
        foreach (double item in arr)
        {
            writer.WriteLine(item.ToString("F9")); //note the F9
        }
    };
