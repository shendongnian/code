    int num1;
    int num2;
    public void Getdata()
    {   
        Console.WriteLine("enter two numbers");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        this.num1 = num1;
        this.num2 = num2;
    }
    public void Showdata()
    {
        Console.WriteLine("First vale {0} Second value {1}",num1,num2);
    }
    static void Main(string[] args)
    {
        Myprog C=new Myprog();
        C.Getdata();
        C.Showdata();
    }
