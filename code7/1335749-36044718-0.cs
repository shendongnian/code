    int n;
    string num = Console.ReadLine();
    if (num == null) {
        // ERROR, No lines available to read.
    }
    if (!Int32.TryParse(num,out n)) {
        // ERROR, Could not parse num.
    }
    int[,] ar = new int[n,6];
