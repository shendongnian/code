    using System;
    class Find
    {
        public static void Main()
        {
            int[] Year = {1930, 2000, 2020};
            string[] Months = {"January", "May", "December"};
 
            int k;
            int[] NumOfCars = {10, 5, 200};
            Console.Write("enter the year");
            year=int.Parse(Console.ReadLine());
            //Console.Write("search the year");
            for(int i=0;i<Year.Length-1;i++)
            {
                if(year==Year[i])
                    k=i;
            }
            Console.Write("Result{0},{1],{2}",Year[k],Months[k],NumOfCars[k]);
       }
    }
