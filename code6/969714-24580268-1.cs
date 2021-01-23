    var raw = new double[][][]
    {
        new double[][]
        {
            new double[]
            {
                1,
                3
            },
            new double[]
            {
                2,
                4
            }
        },
        new double[][]
        {
            new double[]
            {
                5,
                7
            },
            new double[]
            {
                6,
                8
            }
        }
    };
    Console.WriteLine(raw[0][0][0]); //1
    Console.WriteLine(raw[1][1][0]); //6
    Console.ReadKey();
