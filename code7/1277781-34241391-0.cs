    double[,] a = new double[10, 10];
    Random x = new Random();
    string s = "";
    var colsum = new List<int>();
    for (int r = 0; r < 10; r++)
    {
        var col = 0;
        for (int c = 0; c < 10; c++)
        {
            col += x.Next(1, 21);
            a[r, c] = col;
            s = s + a[r, c].ToString() + "\t";
        }
        colsum.Add(col);
    }
    foreach(var col in colsum){
        Console.WriteLine(colsum.ToString());
    }
