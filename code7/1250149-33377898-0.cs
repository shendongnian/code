    decimal[] UniqueSalary = { 30000, 40000, 50000, 55000, 60000 };
            decimal raise = 0.0M;
            Console.WriteLine("Please enter a raise amount");
            raise = int.Parse(Console.ReadLine());
            for (int i = 0; i < UniqueSalary.Length; i++)
                UniqueSalary[i] += raise;
            for(int i = 0; i < UniqueSalary.Length; i++)
                Console.WriteLine(" {0}", UniqueSalary[i]);
            Console.ReadLine();
