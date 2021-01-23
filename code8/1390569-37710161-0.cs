    public class Test
    {
        public static void Main()
        {
            int val = Convert.ToInt32(Console.ReadLine());
            for (int i=0; i<val; i++ )
            {
                string input = Console.ReadLine();
                int a = Convert.ToInt32(input.Split()[0]);
                int b = Convert.ToInt32(input.Split()[1]);
                if (a==0)
                {
                    Console.WriteLine(0);
                } else if(b==0)
                {
                    Console.WriteLine(1);
                } else {
                   Console.WriteLine (Math.Pow(a%10,b%4) %10);
            }
        }
    }
    
        
