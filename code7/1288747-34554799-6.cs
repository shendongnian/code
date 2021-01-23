    Console.WriteLine("enter 3 num");
    int num1 = Convert.ToInt32(Console.ReadLine());
    int num2 = Convert.ToInt32(Console.ReadLine());
    int num3 = Convert.ToInt32(Console.ReadLine());
    
    int a = Math.Min(num1,num2);
    int b = Math.Max(num1,num2);
    int num = a;
    while(num <= b)
    {
       if(num%num3 ==0)
          Console.WriteLine("{0}, {1}/{2}={3}", num, num,num3, num/num3);
       num++;
    }
