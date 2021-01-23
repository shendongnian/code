    public static void GetSales(string[] monthArray, double[] monthlySales )
                               //     ^^ changed here      ^^
    {
        for (int i = 0; i < 12; i++)
        {
            Console.WriteLine("Please enter Monthly Sales for {0}", monthArray[i]);
           monthlySales[i] = Convert.ToDouble(Console.ReadLine());
        }
    }
    static void Main(string[] args)
    {
        string[] monthArray =new string[12] {"January", "FEBRUARY","March","April","May","June","July","August","September","October","Novemember","December"};
        double[] monthlySales= new double[12];
        GetSales(monthArray, monthlySales);
        //         ^^ changed here  ^^
        Console.ReadLine();
    }//main
