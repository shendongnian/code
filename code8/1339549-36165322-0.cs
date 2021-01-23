    public static Task<int> RunALot()
    {
        return Task.Run(() =>
        {
            int temp = 0;
            for (int ini = 0; ini <= 40000; ini++)
            {
                temp += ini;
            }
            return temp;
        });
    }
