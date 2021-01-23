    static void Main(string[] args)
    {
        Matrix<Matrix<double>> src = BuildMatrix();
        Matrix<double> dest = Flatten(src);
        Console.WriteLine(dest);
        Console.ReadLine();
    }
