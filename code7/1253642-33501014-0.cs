    void Main()
    {
        var input = "123456789";
        var size = (int)Math.Sqrt(input.Length);
        var table = new char[size, size];
        for (var i = 0; i < input.Length; ++i)
        {
            table[i / size, i % size] = input[i];
        }
        
        var result = new StringBuilder();
        
        for (var i = 0; i < size; ++i)
        {
            for (var j = size - 1; j >= 0; --j)
            {
                result.Append(table[j, i]);
            }
        }
        Console.WriteLine(result.ToString());
    }
