    namespace Wip
    {
        class Program
        {
            static void Main(string[] args)
            {
                string strNum;
                int num;
                int i = 0;
                int sum = 0;
                do //repeat asking for user input
                {
                    Console.WriteLine("Please enter another integer between 1 and 100"); // asks for user input
                    strNum = Console.ReadLine();
                    if (int.TryParse(strNum, out num)) //input is stored as num2
                    {
                        if (num < 101) 
                        {
                            i++;
               
         sum += num;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("No of integers entered is {0} {1}", i, sum); //output calculation 
                            break;
                        }
                    }
                }
                while (i < 100);
        }
    }
