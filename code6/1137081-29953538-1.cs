    private static void Main(string[] args)
    {
        MakePi(4);
        Console.ReadLine();
    }
    public static int[] MakePi(int n)
    {
        var pi = Math.PI;
        var piString = pi.ToString().Remove(1, 1);
        var newPi = new int[n];
        for (var i = 0; i < n; i++)
        {
            newPi[i] = int.Parse(piString[i].ToString());
            Console.Write(newPi[i]);
        }
        return newPi;
    }
