    for (int i = 0; i < data[0].Length; i++)
    {
        if (data[0][i] == "January")
        {
            for (int a = 0; a < data.Length; a++)
            {
                if (a != 0)
                {
                    Console.Write(" ");
                }
                Console.Write(data[a][i] + " ");
            }
            Console.WriteLine();
        }
    }
